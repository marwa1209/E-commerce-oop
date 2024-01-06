using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class Store
    {
        public List<Product> Shop = new List<Product>();
        public Store()
        {
            if (File.Exists("Products.json"))
            {
                string json = File.ReadAllText("Products.json");
                Shop = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            else
            {
                Shop = new List<Product>();
            }
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



        public void AddProduct(string InputId, string name, string price, string stock, string description)
        {
            //check if the id is a number , if num go to the next validationif not create a random id 
            int Id = CheckProductId(InputId);
            //if the id already exist - i create a random id
            for (int i = 0; i < Shop.Count; i++)
            {
                while (Shop[i].ProductID == Id)
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

            Product NewProduct = new Product(Id, Name, Price, Stock, Description);
            Shop.Add(NewProduct);
            string json = JsonConvert.SerializeObject(Shop, Formatting.Indented);
            File.WriteAllText("Products.json", json);
        }







        public List<Product> GetProducts()
        {
            return Shop;
        }



    }
}
