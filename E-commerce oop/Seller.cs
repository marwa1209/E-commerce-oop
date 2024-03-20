using Newtonsoft.Json;
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

        public void EditProduct(List<Product> shop, int InputId, string seller)
        {




            foreach (var productUpdate in shop)
            {
                if (productUpdate.ProductID == InputId && productUpdate.SellerName == seller)
                {
                    Console.WriteLine("NOW YOU CAN UPDATE THE PRODUCT!!");

                    Console.Write("Enter product new name: ");
                    string newproductName = Console.ReadLine();
                    Console.Write("Enter product new price: ");
                    int newproductPrice = int.Parse(Console.ReadLine());
                    Console.Write("Enter product new quantity: ");
                    int newproductstock = int.Parse(Console.ReadLine());
                    Console.Write("Enter product new description: ");
                    string newproductdesc = Console.ReadLine();

                    productUpdate.ProductName = newproductName;
                    productUpdate.SellerName = seller;
                    productUpdate.Price = newproductPrice;
                    productUpdate.Description = newproductdesc;
                    productUpdate.Quantity = newproductstock;

                    string updatedShop = JsonConvert.SerializeObject(shop, Formatting.Indented);
                    File.WriteAllText("Products.json", updatedShop);


                    foreach (var item in shop)
                    {
                        if (item.SellerName == seller)
                        {
                            Console.WriteLine(item);
                        }
                    }


                    return;
                }


            }
            Console.WriteLine("this product not found or you're not privileged to update it");
        }

    }
}
