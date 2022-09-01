using Area.Application.Contract.Center;
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
        Task<CityViewModel> GetCityInfoBy(long CityId);
        Task<List<CityViewModel>> GetCitiesBy(long StateId);
        Task<List<CenterViewModel>> GetCityCentersBy(long CityId);
    }
}
