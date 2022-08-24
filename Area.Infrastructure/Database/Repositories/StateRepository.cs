using Area.Domain.StateAgg;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Infrastructure.Database.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AreaDbContext _context;
        
        public StateRepository(AreaDbContext context)
        {
            _context = context;
        }

        public async Task Create(StateModel entity)
        {
            try
            {
                await _context.states.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }

        public async Task<List<StateModel>> GetAll()
        {
            return await _context.states.ToListAsync();
        }

        public async Task<StateModel> GetBy(long Id)
        {
            var state =  await _context.states.FirstOrDefaultAsync(x=>x.Id == Id);
            if (state == null) throw new NotFoundException(nameof(state), state);
            return state;
        }

        public async Task Remove(long stateId)
        {
            var state = await _context.states.Include(x=>x.Cities).FirstOrDefaultAsync(x=>x.Id ==stateId);
            if (state == null) throw new NotFoundException(nameof(state),state);
            try
            {
                _context.states.Remove(state);  
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
