using Frameworkes.Auth;
using Frameworks;
using Request.Application.Contract.Service;
using Request.Domain.RequestServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Implements
{
    public class ServiceApplication : IServiceApplication
    {
        private readonly IServiceRepository repository;
        private readonly IAuth _auth;

        public ServiceApplication(IServiceRepository repository, IAuth auth)
        {
            this.repository = repository;
            _auth = auth;
        }

        public async Task CreateService(CreateServiceViewModel commend)
        {
            var service = new ServiceModel(commend.ServiceName, _auth.GetCurrentId());
            await repository.Create(service);
        }

        public async Task EditService(EditServiceViewModel commend)
        {
            var service = await repository.GetBy(commend.ServiceId);
            service.Edit(commend.ServiceName, _auth.GetCurrentId());
            await repository.SaveChanges();
        }

        public async Task<List<ServiceViewModel>> GetAllServiceInfo()
        {
            return (await repository.GetAll()).Select(x => new ServiceViewModel
            {
                CreationDate = x.CreationDate.ToFarsi(),
                ServiceId = x.Id,
                ServiceName = x.ServiceName
            }).ToList();

        }

        public async Task<ServiceViewModel> GetServiceInfoBy(long ServiceId)
        {
            var service = await repository.GetBy(ServiceId);
            return new ServiceViewModel
            {
                CreationDate = service.CreationDate.ToFarsi(),
                ServiceName = service.ServiceName,
                ServiceId = service.Id
            };
        }

        public async Task RemoveService(long ServiceId)
        {
            await repository.Remove(ServiceId);
        }
    }
}
