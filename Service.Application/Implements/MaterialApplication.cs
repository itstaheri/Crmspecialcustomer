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
            var material = new MaterialModel(commend.Description, double.Parse(commend.MaterialPrice), double.Parse(commend.SalaryPrice), commend.Unit, commend.ServiceName, _auth.GetCurrentId());
            await repository.Create(material);
        }


        public async Task EditMaterial(EditMaterialViewModel commend)
        {
            var material = await repository.GetBy(commend.MaterialId);
            material.Edit(commend.Description, double.Parse(commend.MaterialPrice), double.Parse(commend.SalaryPrice), commend.Unit, commend.ServiceName, _auth.GetCurrentId());
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
                Unit = x.Unit,
                CreationDate = x.CreationDate.ToFarsi(),
                ServiceName = x.ServiceName

            }).ToList();
           

            return query;
        }

        public async Task<MaterialViewModel> GetMaterialInfoBy(long MaterialId)
        {
            
            var material = await repository.GetBy(MaterialId);
            var query = new MaterialViewModel
            {
                Description = material.Description,
                CreationDate = material.CreationDate.ToFarsi(),
                MaterialId = material.Id,
                MaterialPrice = material.MaterialPrice,
                SalaryPrice = material.SalaryPrice,
                ServiceName = material.ServiceName,
                Unit = material.Unit,
            };
          
            return query;
        }

        public async Task Remove(long MaterialId)
        {
            await repository.RemoveMaterial(MaterialId);
        }
    }
}
