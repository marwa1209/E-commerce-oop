﻿using System;
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

            //get the product list
            Store store = new Store();
            List<Product> AllProducts = store.GetProducts();

            ShoppingCart shoppingCart = new ShoppingCart();


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
                        User loggedInUserCustomer = account.Login(loginUseremail, loginPassword);
                        if (loggedInUserCustomer != null && loggedInUserCustomer.Role == "customer")
                        {
                            loggedInUserCustomer = new Customer(0, loginUseremail, "", loginPassword);
                            Customer loggedInCustomer = (Customer)loggedInUserCustomer;

                            while (true)
                            {
                                Console.WriteLine("Choose an option:");
                                Console.WriteLine("1. View Profile");
                                Console.WriteLine("2. Edit Profile");
                                Console.WriteLine("3. Add a product to your Cart:");
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
                                        Console.WriteLine("add which product? ");
                                        int ProductNumber = int.Parse(Console.ReadLine());
                                        Console.WriteLine("enter the quantity of the product you want");
                                        int quantity = int.Parse(Console.ReadLine());
                                        shoppingCart.AddProductToCart(loggedInUserCustomer.Id, ProductNumber, quantity, AllProducts);

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
                        else if (loggedInUserCustomer != null && loggedInUserCustomer.Role == "seller")
                        {
                            loggedInUserCustomer = new Seller(0, loginUseremail, "", loginPassword);
                            Seller loggedInCustomer = (Seller)loggedInUserCustomer;

                            while (true)
                            {
                                Console.WriteLine("Choose an option:");
                                Console.WriteLine("1. View Profile");
                                Console.WriteLine("2. Edit Profile");
                                Console.WriteLine("3. Add a new Product");
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

                                        Console.WriteLine("enter product id: ");
                                        string Inputid = Console.ReadLine();
                                        Console.WriteLine("enter product name: ");
                                        string name = Console.ReadLine();
                                        Console.WriteLine("enter price: ");
                                        string price = Console.ReadLine();
                                        Console.WriteLine("enter stock quantity: ");
                                        string stock = Console.ReadLine();
                                        Console.WriteLine("enter product description: ");
                                        string description = Console.ReadLine();
                                        store.AddProduct(Inputid, name, price, stock, description);
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
                            loggedInUserCustomer = new Admin(0, loginUseremail, "", loginPassword);
                            Admin loggedInCustomer = (Admin)loggedInUserCustomer;

                            while (true)
                            {
                                Console.WriteLine("Choose an option:");
                                Console.WriteLine("1. View Profile");
                                Console.WriteLine("2. Edit Profile");
                                Console.WriteLine("3. view users");
                                Console.WriteLine("4. Exit");

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
                        Console.Write("Enter  ID: ");
                        int adminid = int.Parse(Console.ReadLine());
                        Console.Write("Enter admin username: ");
                        string adminUsername = Console.ReadLine();
                        Console.Write("Enter admin email: ");
                        string adminEmail = Console.ReadLine();
                        Console.Write("Enter admin password: ");
                        string adminPassword = Console.ReadLine();
                        account.RegisterAdmin(adminid, adminUsername, adminEmail, adminPassword);
                        break;

                    case "4":
                        Console.Write("Enter admin email: ");
                        string loginAdminEmail = Console.ReadLine();
                        Console.Write("Enter admin password: ");
                        string loginAdminPass = Console.ReadLine();
                        User loggedInUser = account.LoginToCheckAccess(loginAdminEmail, loginAdminPass);

                        if (loggedInUser != null && loggedInUser.Role == "admin")   //null reference error fix
                        {
                            loggedInUser = new Admin(0, loginAdminEmail, "", loginAdminPass);     //to be able to cast
                            Admin admin = (Admin)loggedInUser;
                            Console.Write("Enter new ID: ");
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
                        Console.Write("Enter admin email: ");
                        string loginAdminEmailtodel = Console.ReadLine();
                        Console.Write("Enter admin password: ");
                        string loginAdminPasstodel = Console.ReadLine();
                        User loggedInUsertodel = account.LoginToCheckAccess(loginAdminEmailtodel, loginAdminPasstodel);



                        if (loggedInUsertodel.Role == "admin")
                        {
                            loggedInUsertodel = new Admin(0, loginAdminEmailtodel, "", loginAdminPasstodel);   //to be able to cast
                            Admin admin = (Admin)loggedInUsertodel;
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



                        if (loggedInUsertodelcustomer.Role == "admin")
                        {
                            loggedInUsertodelcustomer = new Admin(0, loginAdminEmailtodelcustomer, "", loginAdminPasstodelcustomer);   //to be able to cast
                            Admin admin = (Admin)loggedInUsertodelcustomer;
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



    }
}
