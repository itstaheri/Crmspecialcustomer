using Exceptions;
using Message.Domain.MessageAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Infrastructure.Database.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageDbContext _dbContext;

        public MessageRepository(MessageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMessages(MessageModel commend)
        {

            try
            {
                await _dbContext.messages.AddAsync(commend);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message,ex.InnerException);
            }
        }

        public async Task<List<MessageModel>> GetAllMessages()
        {
            return await _dbContext.messages.Include(x=>x.UserMessages).AsNoTracking().ToListAsync();
        }

        public async Task<MessageModel> GetMessageBy(long Id)
        {
            var message = await _dbContext.messages.FirstOrDefaultAsync(x=>x.Id == Id && !x.IsHide);
            if (message == null) throw new NotFoundException(Id.ToString(), message);
            return message;
        }

        public async Task<List<UserMessageModel>> GetUserMessagesBy(long UserId)
        {
            return await _dbContext.userMessages.Include(x=>x.Message).Where(x => x.UserId == UserId).ToListAsync();
        }

        public async Task RemoveMessage(long MessageId)
        {
            var message = await GetMessageBy(MessageId);
            
            try
            {
                _dbContext.messages.Remove(message);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }

        public async Task SaveChanges()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new SaveErrorException(ex.Message, ex.InnerException);
            }
        }
    }
}
