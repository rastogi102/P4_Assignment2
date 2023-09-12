using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class UserAuthenticator
    {
        private Dictionary<string, string> userDatabase;

        public UserAuthenticator()
        {
            // Initialize an empty user database (replace with a real database in a production application)
            userDatabase = new Dictionary<string, string>();
        }

        public bool RegisterUser(string username, string password)
        {
            if (userDatabase.ContainsKey(username))
            {
                return false; // Username already exists
            }

            userDatabase[username] = password;
            return true; // Registration successful
        }

        public bool LoginUser(string username, string password)
        {
            if (userDatabase.TryGetValue(username, out string storedPassword))
            {
                return storedPassword == password;
            }

            return false; // User not found
        }

        public bool ResetPassword(string username, string newPassword)
        {
            if (userDatabase.ContainsKey(username))
            {
                userDatabase[username] = newPassword;
                return true; // Password reset successful
            }

            return false; // User not found
        }
    }
}
