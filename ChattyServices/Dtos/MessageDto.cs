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
        public string Author { get; set; }
        public string Text { get; set; }
    }
}
