using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace E_commerce_oop
{
    internal class Customer:User
       {
        public Customer(int id ,string username, string email,string password) : base(id ,username, email, password, "customer")
        {
        }


    }
}

