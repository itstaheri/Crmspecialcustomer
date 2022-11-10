using Frameworkes.Auth;
using Frameworks;
using Service.Application.Contract.Material;
using Service.Domain.ServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Application.Implements
{
    public class MaterialApplication : IMaterialApplication
    {
        private readonly IMaterialRepository repository;
        private readonly IAuth _auth;

        public MaterialApplication(IMaterialRepository repository, IAuth auth)
        {
            this.repository = repository;
            _auth = auth;
        }


        public async Task CreateMaterial(CreateMaterialViewModel commend)
        {
            var material = new MaterialModel(commend.Description, double.Parse(commend.MaterialPrice), 
                double.Parse(commend.SalaryPrice), commend.UnitOfMaterial, commend.ServiceName, double.Parse(commend.UnitPrice), _auth.GetCurrentId());
            await repository.Create(material);
        }


        public async Task EditMaterial(EditMaterialViewModel commend)
        {
            var material = await repository.GetBy(commend.MaterialId);
            material.Edit(commend.Description, double.Parse(commend.MaterialPrice),
                double.Parse(commend.SalaryPrice), commend.UnitOfMaterial, commend.ServiceName, double.Parse(commend.UnitPrice), _auth.GetCurrentId());
            await repository.SaveChanges();


        }

        public async Task<List<MaterialViewModel>> GetAllMaterialsInfo()
        {
            var query = (await repository.GetAll()).Select(x => new MaterialViewModel
            {
                MaterialId = x.Id,
                Description = x.Description,
                MaterialPrice = x.MaterialPrice,
                SalaryPrice = x.SalaryPrice,
                UnitOfMaterial = x.UnitOfMaterial,
                CreationDateString = x.CreationDate.ToFarsi(),
                ServiceName = x.ServiceName,
                UnitPrice= x.UnitPrice,
                CreationDate = x.CreationDate
                

            }).ToList();
           

            return query;
        }

        public async Task<List<ServiceAndDateViewModel>> GetAllServiceNameandDate()
        {

            return (await repository.GetAll())
                .Select(x => new ServiceAndDateViewModel {
                    MaterialId = x.Id,
                    ServiceAndDate = $"{x.ServiceName}  ({x.CreationDate.ToFarsi().Substring(0, 4)}) "
                }
                ).ToList();
        }

        public async Task<MaterialViewModel> GetMaterialInfoBy(long MaterialId)
        {
            var material = await repository.GetBy(MaterialId);
            return new MaterialViewModel
            {
                Description = material.Description,
                SalaryPrice = material.SalaryPrice,
                ServiceName = material.ServiceName,
                CreationDate = material.CreationDate,
                MaterialId = MaterialId,
                MaterialPrice = material.MaterialPrice,
                UnitOfMaterial = material.UnitOfMaterial,
                UnitPrice = material.UnitPrice,
            };
        }

        public async Task<EditMaterialViewModel> GetValueForEdit(long MaterialId)
        {
            
            var material = await repository.GetBy(MaterialId);
            var query = new EditMaterialViewModel
            {
                Description = material.Description,
                MaterialId = material.Id,
                MaterialPrice = material.MaterialPrice.ToString(),
                SalaryPrice = material.SalaryPrice.ToString(),
                ServiceName = material.ServiceName,
                UnitOfMaterial = material.UnitOfMaterial,
                UnitPrice = material.UnitPrice.ToString(),
                
                
            };
          
            return query;
        }

        public async Task Remove(long MaterialId)
        {
            await repository.RemoveMaterial(MaterialId);
        }
    }
}
