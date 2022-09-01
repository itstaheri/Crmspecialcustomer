using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Contract.Request
{
    public interface IRequestApplication
    {
        Task CreateRequest(CreateRequestViewModel commend);
        Task EditRequest(EditRequestViewModel commend);
        //Task<RequestViewModel> GetRequestInfoBy(long ServiceId);
        Task<List<RequestViewModel>> GetAllRequestInfo();
        Task RemoveRequest(long RequestId);
        Task ConfirmRequest(long RequestId);
        Task DeConfirmRequest(long RequestId);
        Task<EditRequestViewModel> GetValueForEdit(long RequestId);
        Task<long> GetStateId(long RequestId);
    }
}
