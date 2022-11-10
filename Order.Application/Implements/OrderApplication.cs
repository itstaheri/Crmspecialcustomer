using Frameworkes;
using Frameworkes.Auth;
using Frameworks;
using Intermediary.Repository;
using Microsoft.AspNetCore.Http;
using Order.Application.Common;
using Order.Application.Contract;
using Order.Application.Contract.OrderDetail;
using Order.Application.Contract.OrderDocumentReceipt;
using Order.Domain.OrderAgg;
using Order.Domain.OrderDocumentReceiptAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Implements
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository repository;
        private readonly IAuth _auth;
        private readonly IFileHelper _fileHelper;
        private readonly IOrderToMaterialRepository _orderToMaterial;
        private readonly IOrderToRequestRepository _orderToRequestRepository;

        public OrderApplication(IOrderRepository repository, IAuth auth, IFileHelper fileHelper, IOrderToMaterialRepository orderToMaterial, IOrderToRequestRepository orderToRequestRepository)
        {
            this.repository = repository;
            _auth = auth;
            _fileHelper = fileHelper;
            _orderToMaterial = orderToMaterial;
            _orderToRequestRepository = orderToRequestRepository;
        }
    
        public async Task<long> ActionOrder(CreateOrderViewModel commend)
        {
            //make a new instance of OrderModel
            var Code = await CodeGenerator.Generate("MOC");
            var order = new OrderModel(commend.RequestId, 0,Code, _auth.GetCurrentId());
            await repository.Create(order);
            return order.Id;
        }

        public async Task AddOrderDetail(CreateOrderDetailViewModel commend)
        {
            var orderDetail = new OrderDetailModel(commend.OrderId, commend.MaterialId, commend.CoreCount,
                commend.CoreCountSide, commend.Value, commend.DiscountRate, commend.ManualDiscount,
                commend.Value*commend.UnitPrice, commend.PayAmount, commend.Description, _auth.GetCurrentId());


            orderDetail.CalculationOfCustomerShare();

            //calculate discount
            if (commend.ManualDiscount > 0) orderDetail.ApplyManualDiscount();
            if(commend.DiscountRate > 0) orderDetail.ApplyDiscountrate();

            //get details of orderDetail by orderId and sum all payamounts + current payamount
            var OrderTotalPrice = (await repository.GetOrderDetailsBy(commend.OrderId)).Sum(x => x.PayAmount) + orderDetail.PayAmount;
            //get orderinfo by orderId
            var order = await repository.GetBy(commend.OrderId);
            //add orderdetail
            order.AddDetail(orderDetail);
            //edit order and set OrderTotalPrice & OrderTotalPriceAfterTax
            order.Edit(OrderTotalPrice, _auth.GetCurrentId());
            //make a new instance of CalculateTax class with CalculateTax1401
            CalculateTax calculateTax = new CalculateTax1401();
            order.AfterTax(calculateTax.Calculate(OrderTotalPrice));

           await repository.SaveChanges();


           
        }

        public async Task EditOrderDetail(EditOrderDetailViewModel commend)
        {
            var orderDetail = await repository.GetOrderDetailInfoBy(commend.OrderDetailId);
            orderDetail.Edit(commend.MaterialId, commend.CoreCount, commend.CoreCountSide,
                commend.Value, commend.DiscountRate, commend.ManualDiscount, commend.Value * commend.UnitPrice,
                commend.PayAmount, commend.Description, _auth.GetCurrentId());

            orderDetail.CalculationOfCustomerShare();

            //calculate discount
            if (commend.ManualDiscount > 0) orderDetail.ApplyManualDiscount();
            if (commend.DiscountRate > 0) orderDetail.ApplyDiscountrate();

            //get details of orderDetail by orderId and sum all payamounts + current payamount
            var OrderTotalPrice = (await repository.GetOrderDetailsBy(commend.OrderId)).Sum(x => x.PayAmount) + orderDetail.PayAmount;
            //get orderinfo by orderId
            var order = await repository.GetBy(commend.OrderId);
            //add orderdetail
            order.AddDetail(orderDetail);
            //edit order and set OrderTotalPrice & OrderTotalPriceAfterTax
            order.Edit(OrderTotalPrice, _auth.GetCurrentId());
            //make a new instance of CalculateTax class with CalculateTax1401
            CalculateTax calculateTax = new CalculateTax1401();
            order.AfterTax(calculateTax.Calculate(OrderTotalPrice));

            await repository.SaveChanges();
        }

        public async Task<List<OrderViewModel>> GetAllOrdersInfo(SearchOrderViewModel commend)
        {
            var orders = (await repository.GetAll()).Select(x => new OrderViewModel
            {
                OrderId = x.Id,
                CreationDate = x.CreationDate,
                Code = x.Code,
                RequestId = x.RequestId,
                TotalPrice = x.TotalPrice,
                TotalPriceAfterTax = x.TotalPriceAfterTax,
            }).ToList();
            foreach (var item in orders)
            {
                item.CompanyName = await _orderToRequestRepository.GetCompanyNamBy(item.RequestId);
                var paidValue = (await repository.CheckPaidOrder(item.OrderId));
                item.IsPaidInFull = paidValue.Item2;
                item.UnpaidAmount = paidValue.Item1;
            }

            #region Search
            if (commend != null)
            {
                if (commend.IsPaidFull && commend.Status)
                {
                    orders = orders.Where(x => x.IsPaidInFull == true).ToList();
                }
                if (!string.IsNullOrEmpty(commend.Code))
                {
                    orders = orders.Where(x => x.Code == commend.Code).ToList();
                }
                if (!string.IsNullOrEmpty(commend.FromDate) && !string.IsNullOrEmpty(commend.ToDate))
                {
                    orders = orders.Where(x => x.CreationDate >= commend.FromDate.ToGeorgianDateTime() && x.CreationDate <= commend.ToDate.ToGeorgianDateTime()).ToList();
                }
                if (!string.IsNullOrEmpty(commend.CompanyName))
                {
                    orders = orders.Where(x => x.CompanyName == commend.CompanyName).ToList();
                }
            }
            #endregion
            return orders;

        }

        public async Task<List<OrderDetailViewModel>> GetOrderDetailsBy(long OrderId)
        {
            var query = (await repository.GetBy(OrderId)).OrderDetails.Select(x=>new OrderDetailViewModel
            {
                CoreCount  = x.CoreCount,
                Description = x.Description,
                CoreCountSide = x.CoreCountSide,
                CreationDate = x.CreationDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                ManualDiscount = x.ManualDiscount,
                CustomerShare = x.CustomerShare,
                OrderDetailId = x.Id,
                MaterialId = x.MaterialId,
                OrderId = x.OrderId,
                PayAmount = x.PayAmount,
                TotalPrice = x.TotalPrice,
                Value = x.Value,
                
            }).ToList();
            
            foreach (var item in query)
            {
                var material = await _orderToMaterial.GetMaterialInfoBy(item.MaterialId);
                item.UnitOfMaterial = material.UnitOfMaterial;
                item.UnitPrice = material.UnitPrice;
                item.SalaryPrice = material.SalaryPrice;
                item.MaterialPrice = material.MaterialPrice;
                item.ServiceName = material.ServiceName;
            }
            return query;
        }

        public async Task<OrderViewModel> GetOrderInfoBy(long OrderId)
        {
            var order = await repository.GetBy(OrderId);
            var orderModel = new OrderViewModel
            {
                IsPaidInFull = order.IsPaidInFull,
                CreationDate = order.CreationDate,
                OrderId = order.Id,
                RequestId = order.RequestId,
                TotalPrice = order.TotalPrice,
                TotalPriceAfterTax = order.TotalPriceAfterTax,

            };
            orderModel.CompanyName = await _orderToRequestRepository.GetCompanyNamBy(order.RequestId);
            return orderModel;
        }

        public async Task PaidOrder(long OrderId)
        {
            //Get orderDerail by Id
            var order = await repository.GetBy(OrderId);
            order.PaidInFull();
            await repository.SaveChanges();
        }

        public async Task RemoveOrder(long OrderId)
        {
            await repository.Remove(OrderId);

        }
       
        public async Task UnPaidOrder(long OrderId)
        {
            //Get orderDerail by Id
            var order = await repository.GetBy(OrderId);
            order.UnPaidInFull();
            await repository.SaveChanges();
        }
    }
}
