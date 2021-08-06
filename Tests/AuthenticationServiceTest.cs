using Microsoft.VisualStudio.TestTools.UnitTesting;
using BugTracker.Services;
using System.Threading.Tasks;
using System;

namespace Tests
{
    [TestClass]
    public class AuthenticationServiceTest
    {
        const string hashedPassword = "NcRZuxGOtSxWN3BkamuKBkEZmv107TBcFIKz+5aLUBqqMzLs";

        [TestMethod]
        public void Compare_Different_Passwords()
        {
            AuthenticationService authenticationService = new();
            Assert.IsFalse(authenticationService.ValidatePassword(hashedPassword, "Yuquita"));

        }
        [TestMethod]
        public void Compare_Equal_Passwords()
        {
            AuthenticationService authenticationService = new();
            Assert.IsTrue(authenticationService.ValidatePassword(hashedPassword, "Mofongo"));
        }
    }
}
