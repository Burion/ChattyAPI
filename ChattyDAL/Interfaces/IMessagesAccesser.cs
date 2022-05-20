using ChattyDAL.Data;
using ChattyDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Interfaces
{
    public interface IMessagesAccesser 
    {
        Task<Message> UpsertMessage(Message message);
        Task<Message> GetMessage(Message message);
        Task<IEnumerable<Message>> GetMessages(Expression<Func<Message, bool>> predicate);
    }
}
