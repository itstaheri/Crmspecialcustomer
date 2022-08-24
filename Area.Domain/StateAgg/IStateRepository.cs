using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Domain.StateAgg
{
    public interface IStateRepository : IGenericRepository<StateModel,StateModel>
    {
        Task Remove(long stateId);
    }
}
