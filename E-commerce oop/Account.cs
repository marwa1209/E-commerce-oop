using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class Account
    {
        private List<User> users;

        public Account()
        {
            if (File.Exists("users.json"))
            {
                string json = File.ReadAllText("users.json");
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            else
            {
                users = new List<User>();
            }
        }

        public void RegisterCustomer(string username ,string email,string password)
        {
            User customer = new Customer(username,email, password);
            users.Add(customer);
            Console.WriteLine($"Customer {username} registered.");
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("users.json", json); // write new  file
        }
        public void RegisterAdmin(string username,string email, string password)
        {
            User admin = new Admin(username,email, password);
            users.Add(admin);
            Console.WriteLine($"Admin {username} registered.");
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("users.json", json);
        }
        public User Login(string email, string password)
        {
            User user = null;

            foreach (User u in users)
            {
                if (u.Email == email && u.Password == password)
                {
                    user = u;
                    break; // Break the loop once a matching user is found
                }
            }

            if (user != null)
            {
                Console.WriteLine($"{user.Role} login successful. Welcome, {user.Username}!");
                return user;
            }
            else
            {
                Console.WriteLine("Invalid credentials. Please try again.");
                return null;
            }
        }
        public List<User> GetUsers()
        {
            return users;
        }
        public bool IsAdmin(User user)
        {
            return user is Admin;
        }

    }
}
