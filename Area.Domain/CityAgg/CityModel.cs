using Area.Domain.CenterAgg;
using Area.Domain.StateAgg;
using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Domain.CityAgg
{
    public class CityModel : BaseEntity
    {
        public CityModel(string cityName, long stateId,long creatorId) : base(creatorId)
        {
            CityName = cityName;
            StateId = stateId;
        }
        public void Edit(string cityName,long creatorId)
        {
            CityName = cityName;
            CreatorId = creatorId;
        }

        public string CityName { get;private set; }
        public long StateId { get;private set; }
        public StateModel State { get; private set; }
        public List<CenterModel> Centers { get; private set; }
    }
}
