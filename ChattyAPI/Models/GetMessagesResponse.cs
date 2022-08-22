using ChattyServices.Dtos;
using System.Collections.Generic;

namespace ChattyAPI.Models
{
    public class GetMessagesResponse
    {
        public string Message { get; set; }
        public IEnumerable<MessageDto> Data { get; set; }
    }
}
