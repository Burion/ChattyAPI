using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ChattyAPI.Models
{
    public class PostMessageModel
    {
        [Required]
        [JsonProperty("receiverId")]
        public string ReceiverId { get; set; }
        [Required]
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
