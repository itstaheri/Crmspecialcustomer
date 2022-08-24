using Area.Domain.CityAgg;
using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Domain.StateAgg
{
    public class StateModel : BaseEntity
    {
        public StateModel(string stateName,long creatorId) : base(creatorId)
        {
            StateName = stateName;
            Cities = new();
        }
        public void Edit(string stateName, long creatorId) 
        {
            StateName = stateName;
            Cities = new();
            CreatorId = creatorId;
        }

        public string StateName { get;private set; }
        public List<CityModel> Cities { get; private set; }
    }
}
