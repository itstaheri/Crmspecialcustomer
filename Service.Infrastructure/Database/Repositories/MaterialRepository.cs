using Exceptions;
using Microsoft.EntityFrameworkCore;
using Service.Domain.ServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Infrastructure.Database.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ServiceDbContext _context;

        public MaterialRepository(ServiceDbContext context)
        {
            _context = context;
        }

        public async Task Create(MaterialModel entity)
        {
            try
            {
                //add material to database & savechange
                await _context.materials.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }

        public async Task<List<MaterialModel>> GetAll()
        {
            //return materialInfo list to MaterialModel
            return await _context.materials.AsNoTracking().ToListAsync();
        }

        public async Task<MaterialModel> GetBy(long Id)
        {
            //get material by Id
            var material = await _context.materials.FirstOrDefaultAsync(x => x.Id == Id);
            if (material == null) throw new NotFoundException(nameof(material),material); //throw exception if material was null
            return material;
        }

        public async Task RemoveMaterial(long MaterialId)
        {
            //get materialInfo by Id 
            var material = await _context.materials.FirstOrDefaultAsync(x => x.Id == MaterialId);
            if (material == null) throw new NotFoundException(nameof(material), material);//throw exception if material was null
            try
            {
                //remove material from database
                _context.materials.Remove(material);
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
