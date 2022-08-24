using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Contract.City
{
    public interface ICityApplication
    {
        Task CreateCity(CreateCityViewModel commend);
        Task RemoveCity(long CityId);
        Task<List<CityViewModel>> GetAllCity();
        Task Edit(EditCityViewModel commend);
        Task<EditCityViewModel> GetValueForEdit(long CityId);
        Task<List<CityViewModel>> GetCitiesBy(long StateId);
    }
}
