using Exceptions;
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
    public class OrderToMaterialRepository : IOrderToMaterialRepository
    {
        private readonly IMaterialRepository repository;

        public OrderToMaterialRepository(IMaterialRepository repository)
        {
            this.repository = repository;
        }

        public async Task<MaterialViewModel> GetMaterialInfoBy(long MaterialId)
        {
            var material = await repository.GetBy(MaterialId);
            if(material==null) throw new NotFoundException(nameof(material),MaterialId);
            return new MaterialViewModel
            {
                Description = material.Description,
                CreationDateString = material.CreationDate.ToFarsi(),
                MaterialId = material.Id,
                MaterialPrice = material.MaterialPrice,
                SalaryPrice = material.SalaryPrice,
                ServiceName = material.ServiceName,
                UnitOfMaterial = material.UnitOfMaterial,
                UnitPrice = material.UnitPrice,
            };
        }

      
    }
}
