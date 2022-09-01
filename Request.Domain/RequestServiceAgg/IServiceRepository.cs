using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Domain.RequestServiceAgg
{
    public interface IServiceRepository : IGenericRepository<ServiceModel,ServiceModel>
    {
        Task Remove(long ServiceId);
    }
}
