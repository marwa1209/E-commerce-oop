using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class Seller:User
    {


        public Seller(int id ,string username,string email, string password ) : base(id ,username,email, password, "seller")
        {
        }

        public void AddProduct(List<Product> products, int productId, string productname, decimal productPrice, int productQuantity , string productDesc)
        {

            if (products.Exists(u => u.ProductID == productId))
            {
                Console.WriteLine("Product already exists.");
                return;
            }

            Product product = new Product( productId,  productname,  productPrice,  productQuantity,  productDesc ,this.Username);
            products.Add(product);

            Console.WriteLine($"Product {productname} added to the system.");
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("products.json", json);
        }


    }
}
