using BugTracker.Persistance;
using BugTracker.Persistance.Models;
using BugTracker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class UserServiceTest
    {
        //[TestMethod]
        //public async Task Return_User_Information()
        //{
        //    var data = new List<User>
        //    { 
        //        new User
        //        {
        //            UserId = 1,
        //            Username = "gonosos",
        //            CreatedDate = DateTime.Now,
        //            LastLogin = DateTime.Now,
        //            LastName = "Rivera",
        //            Name = "Genesis",
        //            Password = "NcRZuxGOtSxWN3BkamuKBkEZmv107TBcFIKz+5aLUBqqMzLs",
        //            ProfilePicture = default
        //        }
        //    }.AsQueryable();
        //    AuthenticationService authService = new();
        //    Mock<DbSet<User>> mockUser = new();
        //    mockUser.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        //    mockUser.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockUser.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockUser.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        //    Mock<BugtrackerContext> mockContext = new();
        //    mockContext.Setup(x => x.User).Returns(mockUser.Object);
        //    var service = new UserService(mockContext.Object,authService);
        //    var userInformation = await service.GetAuthenticatedUserInformationAsync("gonosos", "Mofongo");
        //    Assert.IsTrue(userInformation.Success && !String.IsNullOrEmpty(userInformation.Result.Name));
        //}
    }
}
