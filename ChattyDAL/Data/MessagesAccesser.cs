using ChattyDAL.Interfaces;
using ChattyDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Data
{
    class MessagesAccesser : IMessagesAccesser
    {
        readonly DataAccesser<Message> dataAccesser;

        public MessagesAccesser()
        {
            dataAccesser = new DataAccesser<Message>();
        }

        public Message GetMessage(Message message)
        {
            var item = dataAccesser.GetItem(m => m.Id == message.Id);

            return item;
        }

        public Message UpsertMessage(Message message)
        {
            if (string.IsNullOrEmpty(message.Id))
            {
                //create new message
                message.Id = Guid.NewGuid().ToString();

                return dataAccesser.AddItem(message);
            }

            return dataAccesser.UpdateItem(message);
        }
    }
}
