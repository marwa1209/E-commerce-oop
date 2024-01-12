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
            Store store = new Store();
            List<User> users = account.GetUsers();
            List<Product> shop = store.GetProducts();
            ShoppingCart shoppingcart = new ShoppingCart();


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
                        if (loggedInUserCustomer !=null &&loggedInUserCustomer.Role == "customer")
                        {
                            loggedInUserCustomer = new Customer(loggedInUserCustomer.Id, loggedInUserCustomer.Username, loggedInUserCustomer.Email,  loggedInUserCustomer.Password); ;
                            Customer loggedInCustomer = (Customer)loggedInUserCustomer;
                            CustomerPage:

                            while (true)
                            {
                                Console.WriteLine("Choose an option:");
                                Console.WriteLine("1. View Profile");
                                Console.WriteLine("2. Edit Profile");
                                Console.WriteLine("3. View All Products");
                                Console.WriteLine("4. Add Products To Cart");
                                Console.WriteLine("5. return to Account Page");
                                Console.WriteLine("6. Exit");

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
                                        loggedInCustomer.EditProfile(users, newid,newUsername, newPassword, newEmail);
                                        
                                        break;
                                    case "3":
                                        store.ViewProducts(shop);

                                        break;
                                    case "4":
                                        store.ViewProducts(shop);
                                        Console.WriteLine("Enter the Product ID: ");
                                        int PNum = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter This quantity you want: ");
                                        int quantity = int.Parse(Console.ReadLine());

                                        shoppingcart.AddProductToCart(loggedInUserCustomer.Id, PNum, quantity);

                                        shoppingcart.ReturnCart(loggedInUserCustomer.Id);
                                        break;
                                    case "5":
                                        
                                    case "6":
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
                            loggedInUserCustomer = new Seller(loggedInUserCustomer.Id, loggedInUserCustomer.Username, loggedInUserCustomer.Email, loggedInUserCustomer.Password); ;
                            Seller loggedInCustomer = (Seller)loggedInUserCustomer;

                            while (true)
                            {
                                Console.WriteLine("Choose an option:");
                                Console.WriteLine("1. View Profile");
                                Console.WriteLine("2. Edit Profile");
                                Console.WriteLine("3. Add Product ");
                                Console.WriteLine("4. remove Product ");
                                Console.WriteLine("5. update Product ");
                                Console.WriteLine("6. View All Products ");
                                Console.WriteLine("7. Exit");

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
                                        loggedInCustomer.EditProfile(users,newid, newUsername, newEmail, newPassword);

                                        break;

                                    case "3":
                                        Console.Write("Enter Product ID: ");
                                        string Productid = Console.ReadLine();
                                        Console.Write("Enter Product Name: ");
                                        string productName = Console.ReadLine();
                                        Console.Write("Enter Product Price: ");
                                        string productPrice = Console.ReadLine();
                                        Console.Write("Enter product Quantinty : ");
                                        string stock = Console.ReadLine();
                                        Console.Write("Enter product Description: ");
                                        string productDesc = Console.ReadLine();
                                        loggedInCustomer.AddProduct(shop , Productid, productName, productPrice, stock , productDesc);

                                        break;
                                    case "4":
                                        List<Product> sellerProductstodelete = new List<Product>();
                                        foreach (Product item in shop)
                                        {
                                            if (item.SellerName == loggedInCustomer.Username)
                                            {
                                                sellerProductstodelete.Add(item);

                                            }


                                        }
                                        if (sellerProductstodelete.Count > 0)
                                        {
                                            store.ViewProducts(sellerProductstodelete);
                                            Console.Write("Enter product id: ");
                                            int productid = int.Parse(Console.ReadLine());
                                            loggedInCustomer.DeleteProduct(shop, productid);

                                        }
                                        else
                                        {
                                            Console.WriteLine("This seller did not add any products.");
                                        }

                                        break;
                                    case "5":
                                        List<Product> sellerProductstoupdate = new List<Product>();
                                        foreach (Product item in shop)
                                        {
                                            if (item.SellerName == loggedInCustomer.Username)
                                            {
                                                sellerProductstoupdate.Add(item);

                                            }


                                        }
                                        if (sellerProductstoupdate.Count > 0)
                                        {
                                            store.ViewProducts(sellerProductstoupdate);
                                            Console.Write("Enter product id: ");
                                            int productid = int.Parse(Console.ReadLine());
                                            Console.Write("Enter product new name: ");
                                            string newproductName = Console.ReadLine();
                                            Console.Write("Enter product new price: ");
                                            int newproductPrice = int.Parse(Console.ReadLine());
                                            Console.Write("Enter product new quantity: ");
                                            int newproductstock =int.Parse( Console.ReadLine());
                                            Console.Write("Enter product new description: ");
                                            string newproductdesc = Console.ReadLine();
                                            loggedInCustomer.EditProduct(shop, productid, newproductName, newproductPrice, newproductstock, newproductdesc);

                                        }
                                        else
                                        {
                                            Console.WriteLine("This seller did not add any products.");
                                        }
                                        break;
                                    case "6":
                                     
                                        List<Product> sellerProducts = new List<Product>();
                                        foreach (Product item in shop)
                                        {
                                            if (item.SellerName== loggedInCustomer.Username)
                                            {
                                                sellerProducts.Add(item);
                                              
                                            }

                                        }
                                        if (sellerProducts.Count > 0)
                                        {
                                            store.ViewProducts(sellerProducts);

                                        }
                                        else
                                        {
                                            Console.WriteLine("This seller did not add any products.");
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
                        else if (loggedInUserCustomer != null && loggedInUserCustomer.Role == "admin")
                        {
                            loggedInUserCustomer = new Admin(loggedInUserCustomer.Id, loggedInUserCustomer.Username, loggedInUserCustomer.Email, loggedInUserCustomer.Password ) ;
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
                                Console.WriteLine("7. View All Products  ");
                                Console.WriteLine("8. Exit");

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
                                        loggedInCustomer.EditProfile(users,newid, newUsername, newEmail, newPassword);

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
                                            loggedInCustomer = new Admin(loggedInCustomer.Id, loggedInUserCustomer.Username, loggedInUserCustomer.Email,  loggedInUserCustomer.Password);     //to be able to cast
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
                                            loggedInCustomer = new Admin(loggedInCustomer.Id, loggedInUserCustomer.Username, loggedInUserCustomer.Email,  loggedInUserCustomer.Password);   //to be able to cast
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
                                            loggedInCustomer = new Admin(loggedInCustomer.Id, loggedInUserCustomer.Username, loggedInUserCustomer.Email,  loggedInUserCustomer.Password);   //to be able to cast
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
                                        store.ViewProducts(shop);
                                     
                                        break;
                                    case "8":
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
                        account.RegisterCustomer(id,signupUsername, signupUseremail, signupPassword);
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
