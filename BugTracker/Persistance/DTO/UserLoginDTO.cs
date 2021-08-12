using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BugTracker.Persistance.DTO
{
    public class UserLoginDTO
    {
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }
    }
}
