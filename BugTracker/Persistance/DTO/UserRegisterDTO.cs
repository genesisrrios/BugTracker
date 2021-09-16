using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BugTracker.Persistance.DTO
{
    public class UserRegisterDTO
    {
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }
        [JsonPropertyName("profile_photo")]
        [Required]
        public IFormFile ProfilePhoto { get; set; }
        [JsonPropertyName("second_password")]
        [Required]
        public string SecondPassword { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}
