using AutoMapper;
using ChattyDAL.Data;
using ChattyDAL.Interfaces;
using ChattyDAL.Models;
using ChattyServices.Dtos;
using ChattyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Services
{
    public class MessagesService : IMessagesService
    {
        readonly DataAccesser<Message> dataAccesser;
        private readonly IMapper _mapper;
        private readonly IMessagesAccesser _messagesAccesser;

        public MessagesService(IMapper mapper, IMessagesAccesser messagesAccesser)
        {
            dataAccesser = new DataAccesser<Message>();
            _mapper = mapper;
            _messagesAccesser = messagesAccesser;
        }

        public Task<IEnumerable<MessageDto>> GetMessagesForCurrentUser(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesForUsers(string firstUserId, string secondUserId)
        {
            var messages = await _messagesAccesser.GetMessages(m => 
                (m.AuthorId == firstUserId && m.ReceiverId == secondUserId) 
                || (m.AuthorId == secondUserId && m.ReceiverId == firstUserId));

            var messagesDtos = _mapper.Map<IEnumerable<MessageDto>>(messages);

            return messagesDtos;
        }

        public async Task<MessageDto> UpsertMessage(MessageDto message)
        {
            if (message == null)
                throw new ArgumentNullException($"Message argument is null");

            var messageToUpsert = _mapper.Map<Message>(message);
            
            var addedMessage = await _messagesAccesser.UpsertMessage(messageToUpsert);

            return _mapper.Map<MessageDto>(addedMessage);
        }
    }
}
