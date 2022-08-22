using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattyAPI.Models
{
    public class JwtResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
