using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BugTracker.Persistance.DTO
{
    public class UserSessionInformationDTO
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("profile_picture")]
        public string ProfilePicture { get; set; }
    }
}
