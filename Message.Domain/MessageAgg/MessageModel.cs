using Frameworkes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Domain.MessageAgg
{
    public class MessageModel : BaseEntity
    {
        public MessageModel(long formUserId, string subject, string bodyMessage,long creatorId) : base(creatorId)
        {
            FormUserId = formUserId;
            Subject = subject;
            BodyMessage = bodyMessage;
            IsHide = false;
        }
        public void AddUserMessages(List<UserMessageModel> userMessages)
        {
            UserMessages = new();
            UserMessages.AddRange(userMessages);
        }

        public void Hide()=>IsHide = true;
        public void Show()=>IsHide = false;

        public long FormUserId { get;private set; }
        public string Subject { get;private set; }
        public string BodyMessage { get;private set; }
        public bool IsHide { get;private set; }
        public List<UserMessageModel> UserMessages { get;private set; }
    }
}
