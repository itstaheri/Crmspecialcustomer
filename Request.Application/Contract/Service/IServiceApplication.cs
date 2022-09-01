using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Contract.Service
{
    public interface IServiceApplication
    {
        Task CreateService(CreateServiceViewModel commend);
        Task EditService(EditServiceViewModel commend);
        Task<ServiceViewModel> GetServiceInfoBy(long ServiceId);
        Task<List<ServiceViewModel>> GetAllServiceInfo();
        Task RemoveService(long ServiceId);
    }
}
