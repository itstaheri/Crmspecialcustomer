using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Domain.RequestAgg
{
    public interface IRequestRepository : IGenericRepository<RequestModel,RequestModel>
    {
        Task Remove(long RequestId);
    }
}
