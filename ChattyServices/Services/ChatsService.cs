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
        private readonly IMessagesService _messagesService;

        public ChatsService(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        public async Task<IEnumerable<ChatDto>> GetChatsForUser(string userId)
        {
            var messages = await _messagesService.GetMessagesForUser(userId);

            var lastMessags = messages.GroupBy(
                m => String.Compare(m.AuthorId, m.ReceiverId) > 0
                    ? new { First = m.AuthorId, Second = m.ReceiverId }
                    : new { First = m.ReceiverId, Second = m.AuthorId }
                    , (key, g) => g.OrderByDescending(m => m.SendingDate).First());

            var chats = lastMessags.Select(m => new ChatDto() { Name = m.AuthorId != userId ? m.AuthorId : m.ReceiverId, LastMessage = new MessageDto() { AuthorId = m.AuthorId, Text = m.Text } });

            return chats;
        }
    }
}
