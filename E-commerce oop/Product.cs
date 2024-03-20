using System;
using System.Collections;
using System.Diagnostics;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public string Description { get; set; }
        public string SellerName { get; set; }
        public Product(int productID, string productName, decimal price, int quantity, string description, string sellerName)
        public int Stock { get; set; }
        public string Description { get; set; }


        {
            ProductID = productID;
            ProductName = productName;
            Price = price;

            Quantity = quantity;
            Description = description;
            SellerName = sellerName;
        }

            Stock = stock;
            Description = description;
        }

        public override string ToString()
        {
            return " product id :  " + ProductID + ", ProductName : " + ProductName + " , price : " + Price + " ,stock :  " + Stock + " ,description :  " + Description;
        }



    }
}
