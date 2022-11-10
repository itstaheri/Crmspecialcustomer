using Exceptions;
using Microsoft.EntityFrameworkCore;
using Order.Domain.OrderAgg;
using Order.Domain.OrderDocumentReceiptAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Database.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task AddToOrderDetail(OrderDetailModel commend)
        {
            try
            {
                await _context.orderDetails.AddAsync(commend);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<(double,bool)> CheckPaidOrder(long OrderId)
        {
            //get order info by orderid
            var order = await _context.orders.FirstOrDefaultAsync(x => x.Id == OrderId);
            //get all of orderreceipts by orderid
            var receipts = await _context.orderDocumentReceipts.Where(x => x.OrderId == OrderId).ToListAsync();
            //Total amount paid
            var receiptspaidAmount = receipts.Sum(x => x.AmountPaid);
            //check ispaidfull
            var paidStatus = receiptspaidAmount >= order.TotalPriceAfterTax ? true : false;
            //Unpaid Amount
            var UnpaidAmount = order.TotalPriceAfterTax - receiptspaidAmount;
            return (UnpaidAmount,paidStatus);


        }

        public async Task Create(OrderModel entity)
        {
            try
            {
                await _context.orders.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }


        public async Task<List<OrderModel>> GetAll()
        {
            return await _context.orders.AsNoTracking().ToListAsync();
        }

        public async Task<OrderModel> GetBy(long Id)
        {
            var order = await _context.orders.Include(x => x.OrderDetails).FirstOrDefaultAsync(x => x.Id == Id);
            if (order == null) throw new NotFoundException(nameof(order), Id);
            return order;
        }

        public async Task<OrderDetailModel> GetOrderDetailInfoBy(long OrderDetailId)
        {
            var orderDetail = await _context.orderDetails.FirstOrDefaultAsync(x => x.Id == OrderDetailId);
            if (orderDetail == null) throw new NotFoundException(nameof(orderDetail), OrderDetailId);
            return orderDetail;
        }

        public async Task<List<OrderDetailModel>> GetOrderDetailsBy(long OrderId)
        {
            return await _context.orderDetails.Where(x => x.OrderId == OrderId).AsNoTracking().ToListAsync();
        }



        public async Task Remove(long OrderId)
        {
            var order = await _context.orders.FirstOrDefaultAsync(x => x.Id == OrderId);
            if (order == null) throw new NotFoundException(nameof(OrderId), order);
            try
            {
                _context.orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }


    }
}
