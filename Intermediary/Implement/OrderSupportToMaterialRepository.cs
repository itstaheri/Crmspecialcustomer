using Frameworks;
using Intermediary.Repository;
using Service.Application.Contract.Material;
using Service.Domain.ServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediary.Implement
{
    public class OrderSupportToMaterialRepository : IOrderSupportToMaterialRepository
    {
        private readonly IMaterialRepository repository;

        public OrderSupportToMaterialRepository(IMaterialRepository repository)
        {
            this.repository = repository;
        }

        public async Task<MaterialViewModel> GetMaterialInfoBy(long MaterialId)
        {
            var material = await repository.GetBy(MaterialId);
            return new MaterialViewModel
            {
                Description = material.Description,
                CreationDate = material.CreationDate,
                CreationDateString = material.CreationDate.ToFarsi(),
                MaterialId = material.Id,
                MaterialPrice = material.MaterialPrice,
                ServiceName = material.ServiceName,
                SalaryPrice = material.SalaryPrice,
                UnitOfMaterial = material.UnitOfMaterial,
                UnitPrice = material.UnitPrice,

            };
        }
    }
}
