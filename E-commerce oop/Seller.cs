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
    }
}
