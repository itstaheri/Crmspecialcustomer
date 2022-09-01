using Exceptions;
using Microsoft.EntityFrameworkCore;
using Request.Domain.RequestServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Infrastructure.Database.Implement
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly RequestDbContext _context;

        public ServiceRepository(RequestDbContext context)
        {
            _context = context;
        }

        public async Task Create(ServiceModel entity)
        {
            try
            {
                //add service to database & savechange
                await _context.services.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<ServiceModel>> GetAll()
        {
            //return serviceInfo list to serviceModel
            return await _context.services.AsNoTracking().ToListAsync();
        }

        public async Task<ServiceModel> GetBy(long Id)
        {
            //get serviceinfo by Id
            var service = await _context.services.FirstOrDefaultAsync(x => x.Id == Id);
            if (service == null) throw new NotFoundException(nameof(service), service); //throw exception if service was null
            return service;
        }

        public async Task Remove(long ServiceId)
        {
            //get serviceINfo by Id 
            var service = await _context.services.FirstOrDefaultAsync(x => x.Id == ServiceId);
            if (service == null) throw new NotFoundException(nameof(service), service);//throw exception if service was null
            try
            {
                //remove service from database
                _context.services.Remove(service);
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
