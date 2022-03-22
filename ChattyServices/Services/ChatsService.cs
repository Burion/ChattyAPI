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
    public class ChatsService : IChatsService
    {
        public IEnumerable<ChatDto> GetChatsForUser(string userId)
        {
            var messagesAccesser = new DataAccesser<Message>();
            
            var messages = messagesAccesser.GetItems(i => i.ReceiverLogin == userId || i.AuthorLogin == userId);

            //var messages = new Message[]
            //{
            //    new Message() { AuthorLogin = "Vlad", ReceiverLogin = "John", SendingDate = new DateTime(2022, 3, 4), Text = "Not last messge"},
            //    new Message() { AuthorLogin = "Vlad", ReceiverLogin = "John", SendingDate = new DateTime(2022, 3, 5), Text = "Last message"},
            //    new Message() { AuthorLogin = "John", ReceiverLogin = "Vlad", SendingDate = new DateTime(2022, 3, 2), Text = "Not last message"},
            //    new Message() { AuthorLogin = "Alex", ReceiverLogin = "Vlad", SendingDate = new DateTime(2022, 2, 10), Text = "Not last message"},
            //    new Message() { AuthorLogin = "Vlad", ReceiverLogin = "Alex", SendingDate = new DateTime(2022, 2, 11), Text = "Not last message"},
            //    new Message() { AuthorLogin = "Vlad", ReceiverLogin = "Alex", SendingDate = new DateTime(2022, 2, 15), Text = "Last message"},

            //};

            var lastMessags = messages.GroupBy(
                m => String.Compare(m.AuthorLogin, m.ReceiverLogin) > 0
                    ? new { First = m.AuthorLogin, Second = m.ReceiverLogin }
                    : new { First = m.ReceiverLogin, Second = m.AuthorLogin }
                    , (key, g) => g.OrderByDescending(m => m.SendingDate).First());

            var chats = lastMessags.Select(m => new ChatDto() { Name = m.AuthorLogin != userId ? m.AuthorLogin : m.ReceiverLogin, LastMessage = new MessageDto() { Author = m.AuthorLogin, Text = m.Text } });

            return chats;
        }
    }
}
