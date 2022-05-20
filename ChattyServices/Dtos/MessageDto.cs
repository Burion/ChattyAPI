﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Dtos
{
    public class MessageDto
    {
        public string Id { get; set; }
        public string AuthorId { get; set; }
        public string ReceiverId { get; set; }
        public string Text { get; set; }
        public DateTime SendingDate { get; set; }
    }
}
