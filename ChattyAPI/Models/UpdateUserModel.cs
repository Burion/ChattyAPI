using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ChattyAPI.Models
{
    public class UpdateUserModel
    {
        [Required]
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("profilePicture")]
        public string ProfilePicture { get; set; }
        [JsonProperty("displayedName")]
        public string DisplayedName { get; set; }
        [JsonProperty("oldPassword")]
        public string OldPassword { get; set; }
        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }
    }
}
