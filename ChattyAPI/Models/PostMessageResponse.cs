using ChattyServices.Dtos;

namespace ChattyAPI.Models
{
    public class PostMessageResponse
    {
        public string Message { get; set; }
        public MessageDto Data { get; set; }
    }
}
