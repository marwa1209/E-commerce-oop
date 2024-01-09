using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class ShoppingCart
    {
        public int CustomerId { get; set; }

        public List<CartItem> Items = new List<CartItem>();


        private List<ShoppingCart> ShoppingCarts = new List<ShoppingCart>();

        //view customer cart
        public ShoppingCart ReturnCart(int customerId)
        {
            if (File.Exists("ShoppingList.json"))
            {
                string json = File.ReadAllText("ShoppingList.json");
                var list = JsonConvert.DeserializeObject<List<ShoppingCart>>(json);
                foreach (var item in list)
                {
                    if (item.CustomerId == customerId)
                    {
                        Items = item.Items;
                        ShoppingCart customeCart = new ShoppingCart();
                        customeCart = item;
                        Console.WriteLine($"You have a {customeCart.Items.Count} Products in your cart");

                        foreach (var c in customeCart.Items)

                        {
                            Console.WriteLine($"  you have  quantity {c.Quantity} piece of product {c.Product.ProductName} and the product id is {c.Product.ProductID}");
                        }
                        return customeCart;

                    }
                }
                return null;

            }
            else return null;
        }



        //add product to cart
        public void AddProductToCart(int InputcustomerId, int ProductNumber, int quantity)
        {
            //read all product data
            string data = System.IO.File.ReadAllText("Products.json");
            var allproducts = JsonConvert.DeserializeObject<List<Product>>(data);
            //read shopping carts data
            string json = File.ReadAllText("ShoppingList.json");
            var list = JsonConvert.DeserializeObject<List<ShoppingCart>>(json);

            ShoppingCart foundCart = list.FirstOrDefault(cart => cart.CustomerId == InputcustomerId);



            if (foundCart != null)
            {
                Console.WriteLine("you have a cart");
                Console.WriteLine("---------------------------");
                foreach (var item in foundCart.Items)
                {
                    if (item.Product.ProductID == ProductNumber)
                    {
                        Console.WriteLine(item.Quantity);
                        Console.WriteLine("you have this product");
                        item.Quantity += quantity;
                        Console.WriteLine(item.Quantity);

                        string cartsJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                        File.WriteAllText("ShoppingList.json", cartsJson);


                        return;
                    }

                }
                Console.WriteLine("you don't have this product");
                foreach (var item in foundCart.Items)
                {

                    Product foundProduct = null;

                    foreach (var p in allproducts)
                    {
                        if (p.ProductID == ProductNumber)
                        {
                            foundProduct = p;
                            break;
                        }
                    }
                    CartItem newItem = new CartItem(foundProduct, quantity);
                    foundCart.Items.Add(newItem);


                    Console.WriteLine("you added prouct: " + item.Product.ProductName + "quantity " + item.Quantity);

                    string cartsJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText("ShoppingList.json", cartsJson);

                    break;
                }
                Console.WriteLine("you had a cart ---------------");
            }
            else
            {
                Product searchProduct = null;

                foreach (var p in allproducts)
                {
                    if (p.ProductID == ProductNumber)
                    {
                        searchProduct = p;
                        break;
                    }
                }


                ShoppingCart NewCart = new ShoppingCart();
                CartItem NewCartItem = new CartItem(searchProduct, quantity);
                NewCart.Items.Add(NewCartItem);
                NewCart.CustomerId = InputcustomerId;
                list.Add(NewCart);


                string f = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText("ShoppingList.json", f);



            }
            Console.WriteLine("----------------------------------");

        }
    }

}

