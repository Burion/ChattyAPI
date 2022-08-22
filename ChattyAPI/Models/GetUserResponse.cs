using ChattyServices.Dtos;

namespace ChattyAPI.Models
{
    public class GetUserResponse
    {
        public string Message { get; set; }
        public UserDto Data { get; set; }
    }
}
