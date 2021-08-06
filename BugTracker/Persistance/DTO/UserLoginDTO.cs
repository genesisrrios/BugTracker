using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BugTracker.Persistance.DTO
{
    public class UserLoginDTO
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
