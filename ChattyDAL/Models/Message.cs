using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Models
{
    public class Message
    {
        public string AuthorLogin { get; set; }
        public string ReceiverLogin { get; set; }
        public string Text { get; set; }
        public string AttachedImagePath { get; set; }
        public DateTime SendingDate { get; set; }
    }
}
