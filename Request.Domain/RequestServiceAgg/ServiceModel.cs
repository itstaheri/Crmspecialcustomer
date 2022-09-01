using Frameworkes;
using Request.Domain.RequestAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Domain.RequestServiceAgg
{
    public class ServiceModel : BaseEntity
    {
        public ServiceModel(string serviceName, long creatorId) : base(creatorId)
        {
            ServiceName = serviceName;
            Requests = new();
        }
        public void Edit(string serviceName, long creatorId)
        {
            ServiceName = serviceName;
            CreatorId = creatorId;
        }

        public string ServiceName { get; private set; }
        public List<RequestModel> Requests { get; private set; }
    }
}
