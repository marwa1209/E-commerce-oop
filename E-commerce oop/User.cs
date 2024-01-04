using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User(string username,string email, string password, string role)
        {
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }
    }

}
