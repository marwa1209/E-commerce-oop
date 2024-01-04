using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace E_commerce_oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            List<User> users = account.GetUsers();

            Console.WriteLine("Welcome to Our E-commerce System>>>>>>>>>!");

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Sign Up (Customer)");
                Console.WriteLine("3. Sign Up (Admin)");
                Console.WriteLine("4. Add Seller (Admin)");
                Console.WriteLine("5. remove Seller (Admin)");
                Console.WriteLine("6. remove customer (Admin)");
                Console.WriteLine("7. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter useremail: ");
                        string loginUseremail = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string loginPassword = Console.ReadLine();
                        account.Login(loginUseremail, loginPassword);
                        break;

                    case "2":
                        Console.Write("Enter username: ");
                        string signupUsername = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string signupUseremail = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string signupPassword = Console.ReadLine();
                        account.RegisterCustomer(signupUsername, signupUseremail, signupPassword);
                        break;

                    case "3":
                        Console.Write("Enter admin username: ");
                        string adminUsername = Console.ReadLine();
                        Console.Write("Enter admin email: ");
                        string adminEmail = Console.ReadLine();
                        Console.Write("Enter admin password: ");
                        string adminPassword = Console.ReadLine();
                        account.RegisterAdmin(adminUsername, adminEmail, adminPassword);
                        break;

                    case "4":
                        Console.Write("Enter admin email: ");
                        string loginAdminEmail = Console.ReadLine();
                        Console.Write("Enter admin password: ");
                        string loginAdminPass = Console.ReadLine();
                        User loggedInUser = account.Login(loginAdminEmail, loginAdminPass);
                        loggedInUser= new Admin(loginAdminEmail, "", loginAdminPass);   //to be able to cast
                        

                        if (loggedInUser.Role == "admin" )
                        {    
                            Admin admin = (Admin)loggedInUser;
                            Console.Write("Enter seller username: ");
                            string sellerUsername = Console.ReadLine();
                            Console.Write("Enter seller email: ");
                            string sellerEmail = Console.ReadLine();
                            Console.Write("Enter seller password: ");
                            string sellerPassword = Console.ReadLine();
                            admin.AddSeller(users, sellerUsername, sellerEmail, sellerPassword);

                        }
                        else
                        {
                            Console.WriteLine("can not add seller");
                        }
                        break;
                    case "5":
                        Console.Write("Enter admin email: ");
                        string loginAdminEmailtodel = Console.ReadLine();
                        Console.Write("Enter admin password: ");
                        string loginAdminPasstodel = Console.ReadLine();
                        User loggedInUsertodel = account.Login(loginAdminEmailtodel, loginAdminPasstodel);
                        loggedInUsertodel = new Admin(loginAdminEmailtodel, "", loginAdminPasstodel);   //to be able to cast


                        if (loggedInUsertodel.Role == "admin")
                        {
                            Admin admin = (Admin)loggedInUsertodel;
                            Console.Write("Enter seller email: ");
                            string sellerEmail = Console.ReadLine();
                            admin.DeleteSeller(users, sellerEmail);

                        }
                        else
                        {
                            Console.WriteLine("can not delete seller");
                        }


                        break;
                    case "6":
                        Console.Write("Enter admin email: ");
                        string loginAdminEmailtodelcustomer = Console.ReadLine();
                        Console.Write("Enter admin password: ");
                        string loginAdminPasstodelcustomer = Console.ReadLine();
                        User loggedInUsertodelcustomer = account.Login(loginAdminEmailtodelcustomer, loginAdminPasstodelcustomer);
                        loggedInUsertodelcustomer = new Admin(loginAdminEmailtodelcustomer, "", loginAdminPasstodelcustomer);   //to be able to cast


                        if (loggedInUsertodelcustomer.Role == "admin")
                        {
                            Admin admin = (Admin)loggedInUsertodelcustomer;
                            Console.Write("Enter seller email: ");
                            string customerEmail = Console.ReadLine();
                            admin.DeleteCustomer(users, customerEmail);

                        }
                        else
                        {
                            Console.WriteLine("can not delete seller");
                        }
                        break;
                    case "7":
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }
        }
       

        
    }
}
