using ChattyDAL.Data;
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

        public MessagesService()
        {
            dataAccesser = new DataAccesser<Message>();
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
    }
}
