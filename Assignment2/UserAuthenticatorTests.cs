using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2;

namespace Assignment2
{
    [TestFixture]
    public class UserAuthenticatorTests
    {
        private UserAuthenticator userAuthenticator;

        [SetUp]
        public void Setup()
        {
            userAuthenticator = new UserAuthenticator();
        }

        [Test]
        public void TestUserRegistration_Success()
        {
            // Register a new user with valid credentials
            Assert.IsTrue(userAuthenticator.RegisterUser("newUser", "password123"));
        }

        [Test]
        public void TestUserRegistration_Failure()
        {
            // Arrange: Register a user with an initial username and password
            string username = "existingUser";
            string initialPassword = "password123";

            Assert.IsTrue(userAuthenticator.RegisterUser(username, initialPassword));

            // Act: Attempt to register the same user again
            bool registrationResult = userAuthenticator.RegisterUser(username, "newPassword123");

            // Assert: Ensure that the registration fails (returns false)
            Assert.IsFalse(registrationResult, "Registration with an existing username should fail.");
        }


        [Test]
        public void TestUserLogin_Success()
        {
            // Arrange: Register a user with valid credentials
            string username = "existingUser";
            string password = "password123";

            Assert.IsTrue(userAuthenticator.RegisterUser(username, password));

            // Act: Attempt to log in with the correct credentials
            bool loginResult = userAuthenticator.LoginUser(username, password);

            // Assert: Ensure that the login is successful
            Assert.IsTrue(loginResult, "Login with correct credentials should be successful.");
        }


        [Test]
        public void TestUserLogin_Failure()
        {
            // Attempt to login with incorrect credentials
            Assert.IsFalse(userAuthenticator.LoginUser("nonExistentUser", "wrongPassword"));
        }

        [Test]
        public void TestPasswordReset_Success()
        {
            // Arrange: Register a user with valid initial password
            string username = "existingUser";
            string initialPassword = "password123";
            string newPassword = "newPassword123";

            Assert.IsTrue(userAuthenticator.RegisterUser(username, initialPassword));

            // Act: Reset the user's password
            bool resetResult = userAuthenticator.ResetPassword(username, newPassword);

            // Assert: Ensure that the password reset is successful
            Assert.IsTrue(resetResult, "Password reset should be successful.");

            // Additional Assert: Attempt to log in with the new password
            bool loginResult = userAuthenticator.LoginUser(username, newPassword);
            Assert.IsTrue(loginResult, "Login with the new password should be successful.");
        }

        [Test]
        public void TestPasswordReset_Failure()
        {
            // Attempt to reset the password for a non-existent user
            Assert.IsFalse(userAuthenticator.ResetPassword("nonExistentUser", "newPassword123"));
        }
    }

}
