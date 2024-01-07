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
            List<Product>products=new List<Product>();
 

            Console.WriteLine("Welcome to Our E-commerce System>>>>>>>>>!");

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Sign Up (Customer)");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter useremail: ");
                        string loginUseremail = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string loginPassword = Console.ReadLine();
                        User loggedInUserCustomer = account.Login(loginUseremail, loginPassword);
                        if (loggedInUserCustomer != null && loggedInUserCustomer.Role == "customer")
                        {
                            loggedInUserCustomer = new Customer(loggedInUserCustomer.Id, loggedInUserCustomer.Email, loggedInUserCustomer.Username, loggedInUserCustomer.Password); ;
                            Customer loggedInCustomer = (Customer)loggedInUserCustomer;

                            while (true)
                            {
                                Console.WriteLine("Choose an option:");
                                Console.WriteLine("1. View Profile");
                                Console.WriteLine("2. Edit Profile");
                                Console.WriteLine("3. Exit");

                                string choiceCustomer = Console.ReadLine();

                                switch (choiceCustomer)
                                {
                                    case "1":
                                        loggedInCustomer.ViewProfile();
                                        break;

                                    case "2":
                                        Console.Write("Enter new ID: ");
                                        int newid = int.Parse(Console.ReadLine());
                                        Console.Write("Enter new username: ");
                                        string newUsername = Console.ReadLine();
                                        Console.Write("Enter new password: ");
                                        string newPassword = Console.ReadLine();
                                        Console.Write("Enter new email: ");
                                        string newEmail = Console.ReadLine();
                                        loggedInCustomer.EditProfile(users, newid, newUsername, newPassword, newEmail);

                                        break;

                                    case "3":
                                        Console.WriteLine("Exiting the program.");
                                        return;

                                    default:
                                        Console.WriteLine("Invalid choice. Please try again.");
                                        break;
                                }
                            }
                        }
                        else if (loggedInUserCustomer != null && loggedInUserCustomer.Role == "seller")
                        {
                            loggedInUserCustomer = new Seller(loggedInUserCustomer.Id, loggedInUserCustomer.Email, loggedInUserCustomer.Username, loggedInUserCustomer.Password); ;
                            Seller loggedInCustomer = (Seller)loggedInUserCustomer;

                            while (true)
                            {
                                Console.WriteLine("Choose an option:");
                                Console.WriteLine("1. View Profile");
                                Console.WriteLine("2. Edit Profile");
                                Console.WriteLine("3. Add Prodct ");
                                Console.WriteLine("4. Exit");

                                string choiceCustomer = Console.ReadLine();

                                switch (choiceCustomer)
                                {
                                    case "1":
                                        loggedInCustomer.ViewProfile();
                                        break;

                                    case "2":
                                        Console.Write("Enter new ID: ");
                                        int newid = int.Parse(Console.ReadLine());
                                        Console.Write("Enter new username: ");
                                        string newUsername = Console.ReadLine();
                                        Console.Write("Enter new password: ");
                                        string newPassword = Console.ReadLine();
                                        Console.Write("Enter new email: ");
                                        string newEmail = Console.ReadLine();
                                        loggedInCustomer.EditProfile(users, newid, newUsername, newPassword, newEmail);

                                        break;
                                    case "3":
                                        Console.Write("Enter Product ID: ");
                                        int Productid = int.Parse(Console.ReadLine());
                                        Console.Write("Enter Product Name: ");
                                        string productName = Console.ReadLine();
                                        Console.Write("Enter Product Price: ");
                                        decimal productPrice = decimal.Parse(Console.ReadLine());
                                        Console.Write("Enter product Quantinty : ");
                                        int productQuantinty = int.Parse(Console.ReadLine());
                                        Console.Write("Enter product Description: ");
                                        string productDesc = Console.ReadLine();
                                        loggedInCustomer.AddProduct(products, Productid, productName, productPrice, productQuantinty , productDesc);

                                        break;
                                    case "4":
                                        Console.WriteLine("Exiting the program.");
                                        return;

                                    default:
                                        Console.WriteLine("Invalid choice. Please try again.");
                                        break;
                                }
                            }
                        }
                        else if (loggedInUserCustomer != null && loggedInUserCustomer.Role == "admin")
                        {
                            loggedInUserCustomer = new Admin(loggedInUserCustomer.Id, loggedInUserCustomer.Email, loggedInUserCustomer.Username,loggedInUserCustomer.Password ) ;
                            Admin loggedInCustomer = (Admin)loggedInUserCustomer;

                            while (true)
                            {
                                Console.WriteLine("Choose an option:");
                                Console.WriteLine("1. View Profile");
                                Console.WriteLine("2. Edit Profile");
                                Console.WriteLine("3. view users");
                                Console.WriteLine("4. Add Seller ");
                                Console.WriteLine("5. remove Seller");
                                Console.WriteLine("6. remove customer ");
                                Console.WriteLine("7. Exit");

                                string choiceCustomer = Console.ReadLine();

                                switch (choiceCustomer)
                                {
                                    case "1":
                                        loggedInCustomer.ViewProfile();
                                        break;

                                    case "2":
                                        Console.Write("Enter new id: ");
                                        int newid = int.Parse(Console.ReadLine());
                                        Console.Write("Enter new username: ");
                                        string newUsername = Console.ReadLine();
                                        Console.Write("Enter new password: ");
                                        string newPassword = Console.ReadLine();
                                        Console.Write("Enter new email: ");
                                        string newEmail = Console.ReadLine();
                                        loggedInCustomer.EditProfile(users, newid, newUsername, newPassword, newEmail);

                                        break;
                                    case "3":
                                        foreach (var item in users)
                                        {
                                            Console.WriteLine($" {item.Role} =======> Id => {item.Id}  Name => {item.Username}  Email => {item.Email} ");
                                        }
                                        break;

                                    case "4":

                                        if (loggedInCustomer != null && loggedInCustomer.Role == "admin")   //null reference error fix
                                        {
                                            loggedInCustomer = new Admin(loggedInCustomer.Id, loggedInUserCustomer.Email, loggedInUserCustomer.Username, loggedInUserCustomer.Password);     //to be able to cast
                                            Admin admin = (Admin)loggedInCustomer;
                                            Console.Write("Enter seller ID: ");
                                            int sellerid = int.Parse(Console.ReadLine());
                                            Console.Write("Enter seller username: ");
                                            string sellerUsername = Console.ReadLine();
                                            Console.Write("Enter seller email: ");
                                            string sellerEmail = Console.ReadLine();
                                            Console.Write("Enter seller password: ");
                                            string sellerPassword = Console.ReadLine();
                                            admin.AddSeller(users, sellerid, sellerUsername, sellerEmail, sellerPassword);

                                        }
                                        else
                                        {
                                            Console.WriteLine("you can not add seller");
                                        }
                                        break;
                                    case "5":

                                        if (loggedInCustomer.Role == "admin")
                                        {
                                            loggedInCustomer = new Admin(loggedInCustomer.Id, loggedInUserCustomer.Email, loggedInUserCustomer.Username, loggedInUserCustomer.Password);   //to be able to cast
                                            Admin admin = (Admin)loggedInCustomer;
                                            Console.Write("Enter seller email: ");
                                            string sellerEmail = Console.ReadLine();
                                            admin.DeleteSeller(users, sellerEmail);

                                        }

                                        else
                                        {
                                            Console.WriteLine("you can not delete seller");
                                        }


                                        break;
                                    case "6":
                                        Console.Write("Enter admin email: ");
                                        string loginAdminEmailtodelcustomer = Console.ReadLine();
                                        Console.Write("Enter admin password: ");
                                        string loginAdminPasstodelcustomer = Console.ReadLine();
                                        User loggedInUsertodelcustomer = account.LoginToCheckAccess(loginAdminEmailtodelcustomer, loginAdminPasstodelcustomer);



                                        if (loggedInCustomer.Role == "admin")
                                        {
                                            loggedInCustomer = new Admin(loggedInCustomer.Id, loggedInUserCustomer.Email, loggedInUserCustomer.Username, loggedInUserCustomer.Password);   //to be able to cast
                                            Admin admin = (Admin)loggedInCustomer;
                                            Console.Write("Enter Customer email: ");
                                            string customerEmail = Console.ReadLine();
                                            admin.DeleteCustomer(users, customerEmail);

                                        }

                                        else
                                        {
                                            Console.WriteLine("you can not delete customer");
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
                        else
                        {
                            Console.WriteLine("You are not authorized to view or edit a customer profile.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter  ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter username: ");
                        string signupUsername = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string signupUseremail = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string signupPassword = Console.ReadLine();
                        account.RegisterCustomer(id, signupUsername, signupUseremail, signupPassword);
                        break;

                    case "3":
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
