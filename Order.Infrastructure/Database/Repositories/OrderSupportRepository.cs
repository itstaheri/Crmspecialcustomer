using Exceptions;
using Microsoft.EntityFrameworkCore;
using Order.Domain.OrderSupportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Database.Repositories
{
    public class OrderSupportRepository : IOrderSupportRepository
    {
        private readonly OrderDbContext _context;

        public OrderSupportRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task Create(OrderSupportModel entity)
        {
            try
            {
                await _context.orderSupports.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<OrderSupportModel>> GetAll()
        {
            return await _context.orderSupports.AsNoTracking().ToListAsync();
        }

        public async Task<OrderSupportModel> GetBy(long Id) 
        {
            var orderSupport = await _context.orderSupports.FirstOrDefaultAsync(x => x.Id == Id);
            if (orderSupport == null) throw new NotFoundException(nameof(orderSupport), Id);
            return orderSupport;
        }

        public async Task Remove(long SupportId)
        {
            var ordeSupportr = await GetBy(SupportId);
            try
            {
                _context.orderSupports.Remove(ordeSupportr);
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
