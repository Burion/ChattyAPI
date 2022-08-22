using ChattyServices.Dtos;
using System.Collections.Generic;

namespace ChattyAPI.Models
{
    public class GetUsersResponse
    {
        public string Message { get; set; }
        public IEnumerable<UserDto> Data { get; set; }
    }
}
