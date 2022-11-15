using Message.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Services
{
    public interface IMessageApplication
    {
        Task CreateMessage(CreateMessageViewModel commend);

        Task HideMessage(long MessageId);
        Task ShowMessage(long MessageId);
        Task IsRead(long MessageId, long UserId);
        Task<MessageViewModel> GetMessageDetailBy(long MessageId);
        Task<List<MessageViewModel>> GetAllMessages(MessageSearchViewModel commend);
        Task RemoveMessage(long MessageId);
        Task<List<MessageViewModel>> GetUnreadMessageFromUser(long UserId);


    }
}
