using Exceptions;
using Microsoft.EntityFrameworkCore;
using Order.Domain.OrderDocumentReceiptAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Database.Repositories
{
    public class OrderDocumentReceiptRepository : IOrderDocumentReceiptRepository
    {
        private readonly OrderDbContext _context;

        public OrderDocumentReceiptRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task Create(OrderDocumentReceiptModel entity)
        {
            try
            {
                await _context.orderDocumentReceipts.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<OrderDocumentReceiptModel>> GetAll()
        {
            return await _context.orderDocumentReceipts.AsNoTracking().ToListAsync();
        }

        public async Task<OrderDocumentReceiptModel> GetBy(long Id)
        {
            var orderDocumentReceipts = await _context.orderDocumentReceipts.Include(x=>x.Order).FirstOrDefaultAsync(x => x.Id == Id);
            if (orderDocumentReceipts == null) throw new NotFoundException(nameof(orderDocumentReceipts), Id);
            return orderDocumentReceipts;
        }

        public async Task Remove(long id)
        {
            var orderDocumentReceipts = await _context.orderDocumentReceipts.FirstOrDefaultAsync(x => x.Id == id);
            if (orderDocumentReceipts == null) throw new NotFoundException(nameof(id), orderDocumentReceipts);
            try
            {
                _context.orderDocumentReceipts.Remove(orderDocumentReceipts);
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
