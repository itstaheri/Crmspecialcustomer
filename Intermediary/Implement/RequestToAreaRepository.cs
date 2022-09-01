using Area.Application.Contract.City;
using Intermediary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediary.Implement
{
    public class RequestToAreaRepository : IRequestToAreaRepository
    {
        private readonly ICityApplication _city;

        public RequestToAreaRepository(ICityApplication city)
        {
            _city = city;
        }

        public async Task<CityViewModel> GetCityInfo(long cityId)
        {
            return await _city.GetCityInfoBy(cityId);
        }
    }
}
