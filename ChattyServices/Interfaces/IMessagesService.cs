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
        IEnumerable<MessageDto> GetMessagesForUsers(string firstUserId, string secondUserId);
        IEnumerable<MessageDto> GetMessagesForCurrentUser(string userId);
        MessageDto UpsertMessage(MessageDto message);
    }
}
