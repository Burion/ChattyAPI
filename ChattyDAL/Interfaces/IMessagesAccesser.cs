using ChattyDAL.Data;
using ChattyDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Interfaces
{
    public interface IMessagesAccesser 
    {
        Message UpsertMessage(Message message);
        Message GetMessage(Message message);
    }
}
