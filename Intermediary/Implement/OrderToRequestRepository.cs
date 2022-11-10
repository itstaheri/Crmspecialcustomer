using Frameworks;
using Intermediary.Repository;
using Order.Domain.OrderAgg;
using Request.Domain.RequestAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediary.Implement
{
    public class OrderToRequestRepository : IOrderToRequestRepository
    {
        private readonly IRequestRepository request;

        public OrderToRequestRepository(IRequestRepository request)
        {
            this.request = request;
        }

      

        public async Task<string> GetCompanyNamBy(long RequestId)
        {
            return  request.GetBy(RequestId).Result.CompanyName;

        }
    }
}
