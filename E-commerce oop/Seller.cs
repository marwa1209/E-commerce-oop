using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_oop
{
    internal class Seller:User
    {
        public Seller(string username,string email, string password ) : base(username,email, password, "seller")
        {
        }
    }
}
