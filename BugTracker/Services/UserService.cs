using BugTracker.Persistance;
using BugTracker.Persistance.DTO;
using BugTracker.Persistance.Models;
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
            bugtrackerContext = context;
            authenticationService = authentication;
        }
        public async Task<AppRes<UserInformationDTO>> GetAuthenticatedUserInformationAsync(string username, string password)
        {
            var result = new AppRes<UserInformationDTO>();

            try
            {
                //check if the provided user name returns a user.
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                    return result;

                var user = await bugtrackerContext.User
                    .Where(x => x.Username == username)
                    .SingleAsync();

                if (user == default)
                {
                    result.Success = false;
                    result.Message = "User does not exist.";
                    return result;
                }
                //check if password is valid.
                var validPassword = authenticationService.ValidatePassword(user.Password, password);
                if (!validPassword)
                {
                    result.Message = "Invalid user name or password.";
                    result.Success = false;
                    return result;
                };

                //return information to save in session
                result.Result = new UserInformationDTO
                {
                    UserId = user.UserId,
                    UserName = user.Username,
                    Name = user.Name,
                    ProfilePicture = user.ProfilePicture,
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
