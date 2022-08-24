using Area.Application.Contract.City;
using Area.Domain.CityAgg;
using Frameworkes.Auth;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Implements
{
    public class CityApplication : ICityApplication
    {
        private readonly ICityRepository repository;
        private readonly IAuth _auth;

        public CityApplication(ICityRepository repository, IAuth auth)
        {
            this.repository = repository;
            _auth = auth;
        }

        public async Task CreateCity(CreateCityViewModel commend)
        {
            var city = new CityModel(commend.CityName,commend.StateId, _auth.GetCurrentId());
            await repository.Create(city);
        }

        public async Task Edit(EditCityViewModel commend)
        {
            var city = await repository.GetBy(commend.CityId);
            city.Edit(commend.CityName, _auth.GetCurrentId());
            await repository.SaveChanges();
        }

        public async Task<List<CityViewModel>> GetAllCity()
        {
            return (await repository.GetAll())
               .Select(x => new CityViewModel { CityId = x.Id,CityName = x.CityName,StateId =x.StateId,StateName = x.State.StateName})
               .ToList();
        }

        public async Task<List<CityViewModel>> GetCitiesBy(long StateId)
        {
           return (await repository.GetAll()).Where(x=>x.StateId == StateId).Select(x=> new CityViewModel
           {
               CityId = x.Id,
               CityName = x.CityName,
               StateId = x.StateId,
               StateName = x.State.StateName,
               CreationDate = x.CreationDate.ToFarsi()
           }).ToList();
        }

        public async Task<EditCityViewModel> GetValueForEdit(long CityId)
        {
            var city = await repository.GetBy(CityId);
            return new EditCityViewModel
            {
                StateId = city.StateId,
               CityId = city.Id,
               CityName = city.CityName,
            };
        }

        public async Task RemoveCity(long CityId)
        {
            await repository.Remove(CityId);
        }
    }
}
