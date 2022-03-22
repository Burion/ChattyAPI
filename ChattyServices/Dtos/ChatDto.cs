using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Dtos
{
    public class ChatDto
    {
        public string Name { get; set; }
        public MessageDto LastMessage { get; set; }
    }
}
