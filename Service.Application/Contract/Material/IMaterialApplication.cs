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
        Task<EditMaterialViewModel> GetValueForEdit(long MaterialId);
        Task<List<MaterialViewModel>> GetAllMaterialsInfo();
        Task<List<ServiceAndDateViewModel>> GetAllServiceNameandDate();
        Task EditMaterial(EditMaterialViewModel commend);  
        Task Remove(long MaterialId);
        Task<MaterialViewModel> GetMaterialInfoBy(long MaterialId);

    }
}
