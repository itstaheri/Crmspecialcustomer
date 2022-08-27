using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Domain.ServiceAgg
{
    public interface IMaterialRepository : IGenericRepository<MaterialModel,MaterialModel>
    {
        Task RemoveMaterial(long MaterialId);
    }
}
