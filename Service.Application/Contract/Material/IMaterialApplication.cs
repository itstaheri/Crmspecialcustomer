using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Application.Contract.Material
{
    
    public interface IMaterialApplication
    {
        Task CreateMaterial(CreateMaterialViewModel commend);
        Task<MaterialViewModel> GetMaterialInfoBy(long MaterialId);
        Task<List<MaterialViewModel>> GetAllMaterialsInfo();
        Task EditMaterial(EditMaterialViewModel commend);  
        Task Remove(long MaterialId);

    }
}
