using Area.Application.Contract.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediary.Repository
{
    public interface IRequestToAreaRepository
    {
        Task<CityViewModel> GetCityInfo(long cityId);

    }
}
