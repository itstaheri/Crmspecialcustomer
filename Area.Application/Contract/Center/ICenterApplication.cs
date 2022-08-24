using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Contract.Center
{
    public interface ICenterApplication
    {
        Task CreateCenter(CreateCenterViewModel commend);
        Task RemoveCenter(long CenterId);
        Task<List<CenterViewModel>> GetAllCenter();
        Task<List<CenterViewModel>> GetAllCityCenters(long CityId);
        Task Edit(EditCenterViewModel commend);
        Task<EditCenterViewModel> GetValueForEdit(long CenterId);

    }
}
