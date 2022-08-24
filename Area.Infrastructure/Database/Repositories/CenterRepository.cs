using Area.Domain.CenterAgg;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Infrastructure.Database.Repositories
{
    public class CenterRepository : ICenterRepository
    {
        private readonly AreaDbContext _context;

        public CenterRepository(AreaDbContext context)
        {
            _context = context;
        }

        public async Task Create(CenterModel entity)
        {
            try
            {
                await _context.centers.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<CenterModel>> GetAll()
        {
            return await _context.centers.Include(x => x.City).ThenInclude(x=>x.State).ToListAsync();
        }

        public async Task<CenterModel> GetBy(long Id)
        {
            var center = await _context.centers.FirstOrDefaultAsync(x => x.Id == Id);
            
            if (center == null) throw new NotFoundException(nameof(center), center);  //check for nullable
            return center;
        }

        public async Task Remove(long CenterId)
        {
            var center = await _context.centers.FirstOrDefaultAsync(x => x.Id == CenterId);
            if (center == null) throw new NotFoundException(nameof(center), center);
            try
            {
                _context.centers.Remove(center);
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
