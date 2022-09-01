using Area.Domain.CityAgg;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Infrastructure.Database.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AreaDbContext _context;

        public CityRepository(AreaDbContext context)
        {
            _context = context;
        }

        public async Task Create(CityModel entity)
        {
            try
            {
                await _context.cities.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<CityModel>> GetAll()
        {
            return await _context.cities.Include(x=>x.State).ToListAsync();

        }

        public async Task<CityModel> GetBy(long Id)
        {
            var city = await _context.cities.Include(x=>x.State).Include(x=>x.Centers).FirstOrDefaultAsync(x => x.Id == Id);
            if (city == null) throw new NotFoundException(nameof(city), city);
            return city;
        }

        public async Task Remove(long CityId)
        {
            var city = await _context.cities.FirstOrDefaultAsync(x => x.Id == CityId);
            if (city == null) throw new NotFoundException(nameof(city), city);
            try
            {
                _context.cities.Remove(city);
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
