using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Domain.MessageAgg
{
    public interface IMessageRepository
    {
        Task AddMessages(MessageModel commend);
        Task<List<MessageModel>> GetAllMessages();
        Task<MessageModel> GetMessageBy(long Id);
        Task RemoveMessage(long MessageId);
        Task SaveChanges();
        Task<List<UserMessageModel>> GetUserMessagesBy(long UserId);


    }
}
