using DocumentFormat.OpenXml.InkML;
using Frameworkes.Auth;
using Intermediary.Repository;
using Message.Application.Contract;
using Message.Application.Contract.UserMessage;
using Message.Application.Services;
using Message.Domain.MessageAgg;
using Message.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Implement
{
    public class MessageApplication : IMessageApplication
    {
        private readonly IMessageRepository repository;
        private readonly IAuth _auth;
        private readonly MessageDbContext _context;
        private readonly IMessageToUserRepository _messageToUserRepository;

        public MessageApplication(IMessageRepository repository, IAuth auth, MessageDbContext context, IMessageToUserRepository messageToUserRepository)
        {
            this.repository = repository;
            _auth = auth;
            _context = context;
            _messageToUserRepository = messageToUserRepository;
        }

        public async Task CreateMessage(CreateMessageViewModel commend)
        {
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _context.Database.BeginTransaction();
            List<UserMessageModel> userMessages = new List<UserMessageModel>();
            var message = new MessageModel(_auth.GetCurrentId(), commend.Subject, commend.BodyMessage, _auth.GetCurrentId());
            foreach (var userId in commend.ToUsersId)
            {
                var userMessage = new UserMessageModel(long.Parse(userId), message.Id);
                userMessages.Add(userMessage);
            }
            message.AddUserMessages(userMessages);
            await repository.SaveChanges();

            await repository.AddMessages(message);
            transaction.Commit();

        }

        public async Task<List<MessageViewModel>> GetAllMessages(MessageSearchViewModel? commend)
        {
            var dateOfMonthAgo = DateTime.Now.Month - 1;
            var userMessage = (await repository.GetUserMessagesBy(_auth.GetCurrentId())).ToList();

            var messages = userMessage.Select(q => q.Message).Select(x => new MessageViewModel
            {
                FormUserId = x.FormUserId,
                Subject = x.Subject,
                BodyMessage = x.BodyMessage,
                IsHide = x.IsHide,
                CreationDate = x.CreationDate,
                Id = x.Id,

            }).ToList();
            if (userMessage.Count > 0)
            {
                foreach (var message in messages)
                {
                    var check = userMessage.Any(x => x.MessageId == message.Id && x.IsRead == true);

                    message.IsReadByCurrentUser = check ? true : false;

                }
            }
            if (commend != null)
            {
                //by index
                if (!string.IsNullOrWhiteSpace(commend.Index))
                    messages = messages.Where(x => x.Subject.Contains(commend.Index) || x.BodyMessage.Contains(commend.Index)).ToList();
                //by date
                if (commend.MonthAgo != null)
                    messages = messages.Where(x => x.CreationDate.Month <= DateTime.Now.Month-1).ToList();
                if (commend.WeekAgo != null)
                    messages = messages.Where(x => x.CreationDate.Day <= DateTime.Now.Day - 7).ToList();
                if (commend.DayAgo != null)
                    messages = messages.Where(x => x.CreationDate.Day < DateTime.Now.Day - 1).ToList();
                if (commend.ToDay != null)
                    messages = messages.Where(x => x.CreationDate.Day == DateTime.Now.Day).ToList();

                //by status of read
                if (commend.IsRead != null)
                    messages = messages.Where(x => x.IsReadByCurrentUser == commend.IsRead).ToList();
            }

            return messages.OrderByDescending(x => x.CreationDate).ToList();
        }

        public async Task<MessageViewModel> GetMessageDetailBy(long MessageId)
        {
            var message = await repository.GetMessageBy(MessageId);
            var username = await _messageToUserRepository.GetUserInfoById(message.FormUserId);
            return new MessageViewModel
            {
                CreationDate = message.CreationDate,
                BodyMessage = message.BodyMessage,
                FormUserId = message.FormUserId,
                Subject = message.Subject,
                Id = message.Id,
                FromUserName = username

            };
        }

        public async Task<List<MessageViewModel>> GetUnreadMessageFromUser(long UserId)
        {
            //Get usermessages by Id
            var usermessages = await repository.GetUserMessagesBy(UserId);
            //Get only isread ==false
            var unreadMessages = usermessages.Where(x => !x.IsRead).ToList();
            List<MessageViewModel> messages = new List<MessageViewModel>();

            //add unread message to (messages) list
            foreach (var message in unreadMessages)
            {
                var messageInfo = await repository.GetMessageBy(message.MessageId);
                messages.Add(new MessageViewModel
                {
                    Subject = messageInfo.Subject,
                    CreationDate = messageInfo.CreationDate,
                    Id = messageInfo.Id,

                });
            }
            return messages.OrderByDescending(x => x.CreationDate).ToList();
        }

        public async Task HideMessage(long MessageId)
        {
            //Get message detail
            var message = await repository.GetMessageBy(MessageId);
            //Hide message by hide method
            message.Hide();
            await repository.SaveChanges();
        }

        public async Task IsRead(long MessageId, long UserId)
        {
            //Get all mesages of user by userId
            var userMessages = await repository.GetUserMessagesBy(UserId);
            //Change isread value to true by ReadMeesage method
            var message = userMessages.FirstOrDefault(x => x.MessageId == MessageId);
            if (message != null)
            {
                if (message.IsRead == false) message.ReadMeesage();
            }

            await repository.SaveChanges();

        }

        public async Task RemoveMessage(long MessageId)
        {
            await repository.RemoveMessage(MessageId);
        }

        public async Task ShowMessage(long MessageId)
        {
            //Get message detail
            var message = await repository.GetMessageBy(MessageId);
            //Show message by hide method
            message.Show();
            await repository.SaveChanges();
        }
    }
}
