using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace E_commerce_oop
{
    internal class Seller:User
    {
        public Seller(int id ,string username,string email, string password ) : base(id ,username,email, password, "seller")
        {
        }

        //check if the new id is an valid int, if not it create a random id.
        static int CheckProductId(string input)
        {
            int id;
            if (int.TryParse(input, out id))
            {

            }
            else
            {
                Random random = new Random();
                id = random.Next(1, 1000);
                Console.WriteLine("we have generated a random id for you: " + id);
            }
            return id;
        }

        static int IsNum(string userInput)
        {
            while (true)
            {
                int num;
                if (int.TryParse(userInput, out num))
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number:");
                    userInput = Console.ReadLine();
                }
            }

        }
        public void AddProduct(List<Product> shop,string InputId, string name, string price, string stock, string description)
        {
            //check if the id is a number , if num go to the next validationif not create a random id 
            int Id = CheckProductId(InputId);
            //if the id already exist - i create a random id
            for (int i = 0; i < shop.Count; i++)
            {
                while (shop[i].ProductID == Id)
                {
                    Random random = new Random();
                    Id = random.Next(1, 101);
                }
            }
            //check if the price is decimal
            decimal Price;
            while (true)
            {
                if (decimal.TryParse(price, out Price))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid decimal price.");
                    price = Console.ReadLine();
                }
            }
            int Stock = IsNum(stock);
            string Name = name;
            string Description = description;
            
            Product NewProduct = new Product(Id, Name, Price, Stock, Description,this.Username );
            shop.Add(NewProduct);
            Console.WriteLine($"Product {Name} added to the system.");
            string json = JsonConvert.SerializeObject(shop, Formatting.Indented);
            File.WriteAllText("Products.json", json);
        }

        public void DeleteProduct(List<Product> shop,  int InputId)
        {
           bool productToDelete = false;

            foreach (Product product in shop)
            {
                if (product.ProductID == InputId)
                {

                    shop.Remove(product);
                    productToDelete = true;
                    break;

                }
            }
            if (productToDelete)
            {
                Console.WriteLine($"Product  deleted successfully.");
                string json = JsonConvert.SerializeObject(shop, Formatting.Indented);
                File.WriteAllText("Products.json", json);
            }
            else
            {
                Console.WriteLine($"product with id {InputId}  not found.");
            }
        }
        public void EditProduct(List<Product> shop, int InputId, string name, int price, int stock, string description)
        {
            Product currentProduct = null;

             foreach (Product product in shop)
            {
                if (product.ProductID == InputId)
                { currentProduct = product;
                    shop.Remove(currentProduct);
                    break; }
            }


                int newStock = stock;
                string newName = name;
                int newPrice = price;
                string newDescription = description;
                Product newProduct = new Product(InputId, newName, newPrice, newStock, newDescription, this.Username);
                shop.Add(newProduct);
                Console.WriteLine($"Product with ID {InputId} updated successfully.");
                string json = JsonConvert.SerializeObject(shop, Formatting.Indented);
                File.WriteAllText("Products.json", json);
            

        }
        public void EditProfile(List<User> users, int newid, string newUsername, string newEmail, string newPassword)
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
            User newuser = new User(newid, newUsername, newEmail, newPassword, Role);

            users.Add(newuser);
            Console.WriteLine("Customer Profile updated successfully!");
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText("users.json", json);
        }
    }
}
