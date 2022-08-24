using Area.Domain.CityAgg;
using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Domain.CenterAgg
{
    public class CenterModel : BaseEntity
    {
        public CenterModel(string centerName, long cityId, string lenght, string weight,long creatorId) : base(creatorId)
        {
            CenterName = centerName;
            CityId = cityId;
            Lenght = lenght;
            Weight = weight;
        }
        public void Edit(string centerName, long cityId, string lenght, string weight,long creatorId)
        {
            CenterName = centerName;
            CityId = cityId;
            Lenght = lenght;
            Weight = weight;
            CreatorId = creatorId;
        }

        public string CenterName { get;private set; }
        public string Lenght { get;private set; }
        public string Weight { get;private set; }
        public long CityId { get; private set; }
        public CityModel City { get;private set; }

        
    }
}
