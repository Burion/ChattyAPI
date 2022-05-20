using ChattyDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Interfaces
{
    public interface IMessagesCosmosAccesser
    {
        Task<Message> AddMessage(Message message);
        // R
        // U
        // D
    }
}
