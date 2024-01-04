using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class Admin :User
    {
        public Admin(int id ,string username,string email ,string password) : base(id ,username, email,password, "admin")
        {
        }
        public void AddSeller(List<User> users,int sellerId, string sellerUsername,string selleremail, string sellerPassword)
        {
            
            if (users.Exists(u => u.Email == selleremail))
            {
                Console.WriteLine("Seller already exists.");
                return;
            }

            User seller = new Seller(sellerId ,sellerUsername, selleremail, sellerPassword);
            users.Add(seller);

            Console.WriteLine($"Seller {sellerUsername} added to the system.");
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("users.json", json);
        }


        public void DeleteSeller(List<User> users, string sellerEmail)
        {
            bool sellerToDelete = false;

            foreach (User user in users)
            {
                if (user.Role=="seller" && user.Email == sellerEmail)
                {
                   
                    users.Remove(user);
                    sellerToDelete = true;
                    break;

                }
            }
            if (sellerToDelete ) 
            {
                Console.WriteLine($"Seller {sellerEmail} deleted successfully.");
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText("users.json", json);
            }
            else
            {
                Console.WriteLine($"Seller {sellerEmail} not found.");
            }
        }

        public void DeleteCustomer(List<User> users, string customerEmail)
        {
            bool customerToDelete = false;

            foreach (User user in users)
            {
                if (user.Role == "customer" && user.Email == customerEmail)
                {
                    users.Remove(user);
                    customerToDelete = true;
                    break;
                }
            }
            if (customerToDelete)
            {
                Console.WriteLine($"Cusromer {customerEmail} deleted successfully.");
                string json = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText("users.json", json);
            }
            else
            {
                Console.WriteLine($"Seller {customerEmail} not found.");
            }
        }
    }
}
