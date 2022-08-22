using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("displayedName")]
        public string DisplayedName { get; set; }
        [JsonProperty("profilePicturePath")]
        public string ProfilePicturePath { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
