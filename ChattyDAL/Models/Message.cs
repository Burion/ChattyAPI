using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Models
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string AuthorId { get; set; }
        public string ReceiverId { get; set; }
        public string Text { get; set; }
        public string AttachedImagePath { get; set; }
        public DateTime SendingDate { get; set; }
    }
}
