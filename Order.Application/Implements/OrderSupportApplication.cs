using Frameworkes.Auth;
using Intermediary.Repository;
using Order.Application.Contract.OrderSupport;
using Order.Domain.OrderSupportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Implements
{
    public class OrderSupportApplication : IOrderSupportApplication
    {
        private readonly IOrderSupportRepository repository;
        private readonly IAuth _auth;
        private readonly IOrderSupportToMaterialRepository _orderSupportToMaterial;

        public OrderSupportApplication(IOrderSupportRepository repository, IAuth auth, IOrderSupportToMaterialRepository orderSupportToMaterial)
        {
            this.repository = repository;
            _auth = auth;
            _orderSupportToMaterial = orderSupportToMaterial;
        }

        public async Task CreateOrderSupport(CreateOrderSupportViewModel commend)
        {
            var orderSupport = new OrderSupportModel(commend.OrderId, commend.OrderDetailId, commend.SupportPrice,
                commend.DiscountRate, commend.ManualDiscount, _auth.GetCurrentId());
            await repository.Create(orderSupport);
        }

        public async Task EditOrderSupport(EditOrderSupportViewModel commend)
        {
            var orderSupport = await repository.GetBy(commend.OrderSupportId);
            orderSupport.Edit(commend.SupportPrice, commend.DiscountRate, commend.ManualDiscount, _auth.GetCurrentId());
            await repository.SaveChanges();
        }

        public async Task<OrderSupportViewModel> GetOrderSupportInfoBy(long OrderSupportId)
        {
            var orderSupport = await repository.GetBy(OrderSupportId); //get orderSupport Detail by Id
            var orderSupportModel = new OrderSupportViewModel
            {
                OrderId = orderSupport.OrderId,
                OrderDetailId = orderSupport.OrderDetailId,
                OrderSupportId = orderSupport.Id,

            };
            return orderSupportModel;

        }

        public Task<List<OrderSupportViewModel>> GetOrderSupportsBy(long OrderId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveOrderSupport(long OrderSupportId)
        {
            throw new NotImplementedException();
        }
    }
}
