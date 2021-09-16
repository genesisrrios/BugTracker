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
        [JsonPropertyName("photo")]
        [Required]
        public IFormFile Photo { get; set; }
        [JsonPropertyName("second_password")]
        [Required]
        public string SecondPassword { get; set; }
        [JsonPropertyName("profile_photo")]
        [Required]
        public string ProfilePhoto { get; set; }
    }
}
