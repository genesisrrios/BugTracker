using BugTracker.Persistance;
using BugTracker.Persistance.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class UserService
    {
        private readonly BugtrackerContext bugtrackerContext;
        private readonly AuthenticationService authenticationService;
        public UserService(BugtrackerContext context,AuthenticationService authentication)
        {
            context = bugtrackerContext;
            authenticationService = authentication;
        }
        public async Task<UserSessionInformationDTO> Login(string username, string password)
        {
            UserSessionInformationDTO result = default;
            //check if the provided username returns a user.
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                return result;

            var user = await bugtrackerContext.User
                .Where(x => x.UserId == username)
                .SingleOrDefaultAsync();
            if(user == default) return result;
            //check if password is valid.
            var validPassword = authenticationService.ValidatePassword(user.Password, password);
            if (!validPassword) return result;

            //return information to save in session
            return new UserSessionInformationDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                ProfilePicture = user.ProfilePicture
            };
        }
    }
}
