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

        public IEnumerable<MessageDto> GetMessagesForCurrentUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageDto> GetMessagesForUsers(string firstUserId, string secondUserId)
        {
            var messages = dataAccesser.GetItems(m => 
                (m.AuthorLogin == firstUserId && m.ReceiverLogin == secondUserId) 
                || (m.AuthorLogin == secondUserId && m.ReceiverLogin == firstUserId));

            var messagesDtos = messages.Select(m => new MessageDto() { Author = m.AuthorLogin, Text = m.Text });

            return messagesDtos;
        }

        public MessageDto UpsertMessage(MessageDto message)
        {
            if (message == null)
                throw new ArgumentNullException($"Message argument is null");

            var messageToUpsert = _mapper.Map<Message>(message);
            
            var addedMessage = _messagesAccesser.UpsertMessage(messageToUpsert);

            return _mapper.Map<MessageDto>(addedMessage);
        }
    }
}
