using Area.Application.Contract.Center;
using Area.Domain.CenterAgg;
using Frameworkes.Auth;
using Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Implements
{
    public class CenterApplication : ICenterApplication
    {
        private readonly ICenterRepository repository;
        private readonly IAuth _auth;
        public CenterApplication(ICenterRepository repository, IAuth auth)
        {
            this.repository = repository;
            _auth = auth;
        }
        public async Task CreateCenter(CreateCenterViewModel commend)
        {
            var center = new CenterModel(commend.CenterName,commend.CityId,commend.Lenght,commend.Weight, _auth.GetCurrentId());
            await repository.Create(center);
        }

        public async Task Edit(EditCenterViewModel commend)
        {
            //get center by id & replace values for edit
            var center = await repository.GetBy(commend.CenterId);
            center.Edit(commend.CenterName,commend.CityId,commend.Lenght,commend.Weight, _auth.GetCurrentId());
            await repository.SaveChanges();
        }

        public async Task<List<CenterViewModel>> GetAllCenter()
        {
            return (await repository.GetAll())
               .Select(x => new CenterViewModel {CenterId = x.Id, CenterName = x.CenterName,
                   CityId = x.CityId, Lenght = x.Lenght, Weight = x.Weight ,CreationDate = x.CreationDate.ToFarsi(),
                   CityName = x.City.CityName,StateName = x.City.State.StateName}).ToList();
        }

        public async Task<List<CenterViewModel>> GetAllCityCenters(long CityId)
        {
            //get all centersValue from cityId
            return (await repository.GetAll()).Where(x=>x.CityId == CityId)
               .Select(x => new CenterViewModel
               {
                   CenterId = x.Id,
                   CenterName = x.CenterName,
                   CityId = x.CityId,
                   Lenght = x.Lenght,
                   Weight = x.Weight,
                   CreationDate = x.CreationDate.ToFarsi(),
                   CityName = x.City.CityName,
                   StateName = x.City.State.StateName
               }).ToList();
        }

        public  async Task<EditCenterViewModel> GetValueForEdit(long CenterId)
        {
            var center = await repository.GetBy(CenterId);
            return new EditCenterViewModel
            {
               CenterId = center.Id,
               CenterName = center.CenterName,
               CityId = center.CityId,
               Lenght = center.Lenght,
               Weight = center.Weight,
            };
        }

        public async Task RemoveCenter(long CenterId)
        {
            await repository.Remove(CenterId);
        }
    }
}
