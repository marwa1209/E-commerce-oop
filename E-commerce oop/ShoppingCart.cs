using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class ShoppingCart
    {
        public int CustomerId { get; set; }

        public List<CartItem> Items = new List<CartItem>();

        //List of shopping carts of the customers
        private List<ShoppingCart> ShoppingCarts = new List<ShoppingCart>();
        public ShoppingCart()
        {
            if (File.Exists("ShoppingList.json"))
            {
                string json = File.ReadAllText("ShoppingList.json");
                ShoppingCarts = JsonConvert.DeserializeObject<List<ShoppingCart>>(json);
            }
            else
            {
                ShoppingCarts = new List<ShoppingCart>();
            }
        }


        public void AddProductToCart(int InputCustomerID, int ProductNumber, int quantity, List<Product> AllProducts)
        {
            ShoppingCart foundCart = null;

            foreach (var cart in ShoppingCarts)
            {
                if (cart.CustomerId == InputCustomerID)
                {
                    foundCart = cart;
                    Console.WriteLine("You have a cart");

                    var searchItem = foundCart.Items.Find(item => item.Product.ProductID == AllProducts[ProductNumber].ProductID);
                    if (searchItem != null)
                    {
                        Console.WriteLine($"You have the product. Current quantity: {searchItem.Quantity}");
                        searchItem.Quantity += quantity;
                        AllProducts[ProductNumber].Stock = AllProducts[ProductNumber].Stock - quantity;
                        string p = JsonConvert.SerializeObject(AllProducts, Formatting.Indented);
                        File.WriteAllText("AllProducts.json", p);

                        Console.WriteLine($"You updated the quantity in your cart to: {searchItem.Quantity}");
                    }
                    else
                    {
                        Console.WriteLine("Product not found in your cart. Adding a new item.");
                        foundCart.Items.Add(new CartItem(AllProducts[ProductNumber], quantity));
                    }

                    break; // Found the desired cart, exit the loop
                }
            }

            // If the cart is not found, create a new cart
            if (foundCart == null)
            {
                Console.WriteLine("You don't have a cart. Creating a new cart.");

                foundCart = new ShoppingCart();
                foundCart.CustomerId = InputCustomerID;
                foundCart.Items.Add(new CartItem(AllProducts[ProductNumber], quantity));
                ShoppingCarts.Add(foundCart);
            }

            string json = JsonConvert.SerializeObject(ShoppingCarts, Formatting.Indented);
            File.WriteAllText("ShoppingCarts.json", json);

        }

        public List<ShoppingCart> GetCarts()
        {
            return ShoppingCarts;
        }


    }
}
