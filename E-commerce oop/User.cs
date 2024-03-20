using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User(int id ,string username,string email, string password, string role)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }
        public void ViewProfile()
        {
            Console.WriteLine($"id is:  {Id}");
            Console.WriteLine($"Username: {Username}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Password: {Password}");
            Console.WriteLine($"Role: {Role}");
        }

        public void EditProfile(List<User> users,int newid, string newUsername, string newPassword, string newEmail)
        {
            User currentUser = null;

            foreach (User user in users)
            {
                if (user.Username == Username)
                {
                    currentUser = user;
                    users.Remove(currentUser);
                    break;

                }
            }
           
            Username = newUsername;
            Password = newPassword;
            Email = newEmail;
            User newuser = new User (newid ,newUsername,newPassword,newEmail,Role);
           
            users.Add(newuser);
            Console.WriteLine("Customer Profile updated successfully!");
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("users.json", json);
        }
    }

}
