using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Domain.CityAgg
{
    public interface ICityRepository : IGenericRepository<CityModel,CityModel>
    {
        Task Remove(long cityId);

    }
}
