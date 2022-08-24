using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Domain.CenterAgg
{
    public interface ICenterRepository : IGenericRepository<CenterModel,CenterModel>
    {
        Task Remove(long CenterId);
    }
}
