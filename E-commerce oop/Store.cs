﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class Store
    {
        private List<Product> shop;

        public Store()
        {
            if (File.Exists("products.json"))
            {
                string json = File.ReadAllText("products.json");
                shop = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            else
            {
                shop = new List<Product>();
            }

        }

        //public  void ViewProducts(List<Product> shop)
        //{
        //    {
        //        foreach (var item in shop)
        //        {
        //            Console.WriteLine($"product id => {item.ProductID} product Name => {item.ProductName} product price => {item.Price} product Quantity => {item.Quantity} product Description =>{item.Description} added by {item.SellerName}");
        //            Console.WriteLine("");

        //        }

        //    }
        //}
        public void ViewProducts(List<Product> shop)
        {
            {

                Console.WriteLine("ID   | Name        | Price         | Description      | Quantity | Seller Name");
                Console.WriteLine("--------------------------------------------------------------------------");


                foreach (var product in shop)
                {
                    Console.WriteLine($"{product.ProductID,-4} | {product.ProductName,-11} | {product.Price,12:C} | {product.Description,-17} | {product.Quantity,-8} | {product.SellerName}");
                }


            }
        }

        public List<Product> GetProducts()
        {
            return shop;
        }

    }
}
