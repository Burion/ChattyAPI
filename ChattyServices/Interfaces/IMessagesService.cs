using ChattyDAL.Models;
using ChattyServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Interfaces
{
    public interface IMessagesService
    {
        Task<IEnumerable<MessageDto>> GetMessagesForUsers(string firstUserId, string secondUserId);
        Task<IEnumerable<MessageDto>> GetMessagesForUser(string userId);
        Task<MessageDto> UpsertMessage(MessageDto message);
    }
}
