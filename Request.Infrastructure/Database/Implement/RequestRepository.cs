using Exceptions;
using Microsoft.EntityFrameworkCore;
using Request.Domain.RequestAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Infrastructure.Database.Implement
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RequestDbContext _context;

        public RequestRepository(RequestDbContext context)
        {
            _context = context;
        }

        public async Task Create(RequestModel entity)
        {
            try
            {
                //add request to database & savechange
                await _context.requests.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

      
        public async Task<List<RequestModel>> GetAll()
        {
            //return requestInfo list to requestModel
            return await _context.requests.Include(x=>x.Service).ToListAsync();
        }

        public async Task<RequestModel> GetBy(long Id)
        {
            //get requestInfo by Id
            var request = await _context.requests.Include(x=>x.Service).FirstOrDefaultAsync(x => x.Id == Id);
            if (request == null) throw new NotFoundException(nameof(request), request); //throw exception if request was null
            return request;
        }

        public async Task Remove(long RequestId)
        {
            //get requestInfo by Id 
            var request = await _context.requests.FirstOrDefaultAsync(x => x.Id == RequestId);
            if (request == null) throw new NotFoundException(nameof(request), request);//throw exception if request was null
            try
            {
                //remove request from database
                _context.requests.Remove(request);
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
