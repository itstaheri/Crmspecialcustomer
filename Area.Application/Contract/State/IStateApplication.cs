using Area.Application.Common;
using Area.Application.Contract.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area.Application.Contract.State
{
    public interface IStateApplication
    {
        Task<ResultMessage> CreateState(CreateStateViewModel commend);
        Task RemoveState(long StateId);
        Task<List<StateViewModel>> GetAllStates();
        Task<ResultMessage> Edit(EditStateViewModel commend);
        Task<EditStateViewModel> GetValueForEdit(long StateId);
        Task<List<CityViewModel>> GetStateCities(long StateId);


    }
}
