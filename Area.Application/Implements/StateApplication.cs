using Area.Application.Common;
using Area.Application.Contract.City;
using Area.Application.Contract.State;
using Area.Domain.StateAgg;
using Frameworkes.Auth;
using Frameworks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Implements
{
    public class StateApplication : IStateApplication
    {
        private readonly IStateRepository repository;
        private readonly IAuth _auth;
        private readonly ILogger<StateApplication> _logger;

        public StateApplication(IStateRepository repository, IAuth auth, ILogger<StateApplication> logger)
        {
            this.repository = repository;
            _auth = auth;
            _logger = logger;
        }

        public async Task<ResultMessage> CreateState(CreateStateViewModel commend)
        {
            var checkState = (await repository.GetAll()).Any(x => x.StateName == commend.StateName); //Checking for duplicates was the state for edit current stateName
            if (checkState) return new ResultMessage(commend.StateName, Status.RepetitiousName); //return message duplicates value
            var userid= _auth.GetCurrentId();
            var state = new StateModel(commend.StateName, _auth.GetCurrentId());
            await repository.Create(state);
            return new ResultMessage(Status.CreateSuccess);

        }

        public async Task<ResultMessage> Edit(EditStateViewModel commend)
        {
            var checkState = (await repository.GetAll()).Any(x => x.StateName == commend.StateName && x.Id != commend.StateId); //Checking for duplicates was the state for edit current stateName
            if (checkState) return new ResultMessage(commend.StateName,Status.RepetitiousName); //return message duplicates value
            var state = await repository.GetBy(commend.StateId);
            state.Edit(commend.StateName, _auth.GetCurrentId());
            await repository.SaveChanges();
            return new ResultMessage(Status.CreateSuccess); // return Success
        }

        public async Task<List<StateViewModel>> GetAllStates()
        {
            return (await repository.GetAll())
                .Select(x => new StateViewModel { CreationDate = x.CreationDate.ToFarsi(), StateId = x.Id, StateName = x.StateName })
                .ToList();
        }

        public async Task<List<CityViewModel>> GetStateCities(long StateId)
        {
            var cityList = new List<CityViewModel>();
            var cities = (await repository.GetBy(StateId)).Cities; //get cities of specific state by stateId
            foreach (var city in cities)
            {
                var value = new CityViewModel
                {
                    CityId = city.Id,
                    CityName = city.CityName,
                    StateId = city.StateId,
                    StateName = city.State.StateName
                };
                cityList.Add(value);
            }
            return cityList;
        }

        public async Task<EditStateViewModel> GetValueForEdit(long StateId)
        {
            var state = await repository.GetBy(StateId);
            return new EditStateViewModel
            {
                StateId = state.Id,
                StateName = state.StateName,
            };
        }

        public async Task RemoveState(long StateId)
        {
            await repository.Remove(StateId);
        }
    }
}
