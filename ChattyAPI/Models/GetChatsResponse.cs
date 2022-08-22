using ChattyServices.Dtos;
using System.Collections.Generic;

namespace ChattyAPI.Models
{
    public class GetChatsResponse
    {
        public string Message { get; set; }
        public IEnumerable<ChatDto> Data { get; set; }
    }
}
