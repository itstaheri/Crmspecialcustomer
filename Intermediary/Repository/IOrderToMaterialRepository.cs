using Service.Application.Contract.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediary.Repository
{
    public interface IOrderToMaterialRepository
    {
        Task<MaterialViewModel> GetMaterialInfoBy(long MaterialId);
    }
}
