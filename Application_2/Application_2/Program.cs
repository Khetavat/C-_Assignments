using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Application_2
{
    
    public  class Collection
    {
        private static List<Product> list = new List<Product>();

        public static void Add(Product product)
        {
            list.Add(product);
            
        }
       
        public static IEnumerable<Product> Get()
        {
            return list.AsEnumerable<Product>();
        }

        internal static bool Remove(Product item2)
        {
            foreach (var item in list)
            {

                if (item.ProductId == item2.ProductId)
                {
                    if (DateTime.Equals(null, item.EndTime))
                    {
                        item.EndTime = DateTime.Now.Date;
                        return true;
                    }

                }
            }
            return false;

        }


        internal static void WriteToFile()
        {
            List<Product> list4 = UpdateList();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\productlist.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, list4);
            stream.Close();

        }

        internal static void WriteToFileForProductId()
        {
            
            IFormatter formatter1 = new BinaryFormatter();
            Stream stream1 = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\productidlist.txt", FileMode.Create, FileAccess.Write);

            formatter1.Serialize(stream1, Product.ProductIdList);
            stream1.Close();
        }

        private static List<Product> UpdateList()
        {
            List<Product> list2 = new List<Product>();
            foreach(var item in ReadFromFile())
            {
                list2.Add(item);
            }

            foreach(var item in list)
            {
                list2.Add(item);
            }
            return list2;
        }

        internal static List<Product> ReadFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            if (File.Exists("C:\\Users\\Vishal.Khetavat\\Desktop\\productlist.txt"))
            {
                Stream stream = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\productlist.txt", FileMode.Open, FileAccess.Read);
                List<Product> User1List = (List<Product>)formatter.Deserialize(stream);

                stream.Close();
                /*
                foreach(var item in User1List)
                {
                    Console.WriteLine(item.UserName);
                    Console.WriteLine(item.Password);
                    Console.WriteLine(item.IsAdmin);
                }*/
                return User1List;
            }
            else
            {
                List<Product> ProductList = new List<Product>();
                return ProductList;
            }
        }



        internal static List<int> ReadFromFileForProductId()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\productidlist.txt", FileMode.Open, FileAccess.Read);
            List<int> User1List = (List<int>)formatter.Deserialize(stream);

            stream.Close();
            
            return User1List;
        }
    }

    [Serializable]
    public class Product
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; } = null;

        public static List<int> ProductIdList = new List<int>();



        internal bool ChoiceInputValidation(string choiceInput)
        {
            foreach (char c in choiceInput)
            {
                if (choiceInput == null)
                {
                    return false;
                }
                if (c >= '1' && c <= '9')
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ProductNameValidation(string ProductNameInput)
        {
            if (ProductNameInput == null)
            {
                return false;
            }
            foreach (char c in ProductNameInput)
            {
                if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c == ' ')
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ProductIdValidation(string ProductIdInput)
        {
            if (ProductIdInput == null)
            {
                return false;
            }

            foreach (char c in ProductIdInput)
            {
                if (c >= '0' && c <= '9')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }
        public void AddNewProduct(Product product)
        {

            do
            {
                Console.WriteLine("Enter a Product Name");
                string ProductNameInput = Console.ReadLine();
                if (ProductNameValidation(ProductNameInput))
                {
                    product.ProductName = ProductNameInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);

            do
            {
                Console.WriteLine("Enter a Product Id from (10 to 100)");
                string ProductIdInput = Console.ReadLine();
                if (ProductIdValidation(ProductIdInput))
                {
                    int ProductIdInput1 = int.Parse(ProductIdInput);

                    if (ProductIdList.Contains(ProductIdInput1) || Collection.ReadFromFileForProductId().Contains(ProductIdInput1))
                    {
                        Console.WriteLine("Enter different proudct id");
                        continue;
                    }
                    product.ProductId = ProductIdInput1;
                    ProductIdList.Add(product.ProductId);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);


            do
            {
                Console.WriteLine("Enter a Price");
                string PriceInput = Console.ReadLine();
                if (ProductIdValidation(PriceInput))
                {
                    double PriceInput1 = double.Parse(PriceInput);
                    product.ProductPrice = PriceInput1;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);

            Collection.Add(product);
        }


        internal void ShowAll()
        {
            Console.Write("{0,-15}", "ProductName");
            Console.Write("{0,-15}", "ProductId");
            Console.Write("{0,-15}", "ProductPrice");


            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Data from Collection list");
            foreach (var item in Collection.Get())
            {
                if (!(DateTime.Equals(item.EndTime, null)))
                {
                }
                else
                {
                    Console.Write("{0,-15}", item.ProductName);
                    Console.Write("{0,-15}", item.ProductId);
                    Console.WriteLine("{0,-15}", item.ProductPrice);

                }
                
            }

            Console.WriteLine() ;
            Console.WriteLine("Data from File");
            foreach (var item in Collection.ReadFromFile())
            {
                if (!(DateTime.Equals(item.EndTime, null)))
                {
                }
                else
                {
                    Console.Write("{0,-15}", item.ProductName);
                    Console.Write("{0,-15}", item.ProductId);
                    Console.Write("{0,-15}", item.ProductPrice);

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal void UpdateProduct(Product product)
        {
            Console.WriteLine("Enter a product id");
            string UserProductId = Console.ReadLine();
            if (ProductIdValidation(UserProductId))
            {
                int UserProductId2 = int.Parse(UserProductId);
                product.ProductId = UserProductId2;
                foreach (var item in Collection.Get())
                {
                    Console.WriteLine(item.ProductId);
                    if (item.ProductId == product.ProductId)
                    {
                        product = item.ShallowCopy();
                        item.EndTime = DateTime.Now.Date;
                        product.StartTime = DateTime.Now.Date;

                        do
                        {
                            Console.WriteLine("Enter a new Product Name");
                            string ProductNameInput = Console.ReadLine();
                            if (ProductNameValidation(ProductNameInput))
                            {
                                product.ProductName = ProductNameInput;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                        } while (true);


                        do
                        {
                            Console.WriteLine("Enter a new Price");
                            string PriceInput = Console.ReadLine();
                            if (ProductIdValidation(PriceInput))
                            {
                                double PriceInput1 = double.Parse(PriceInput);
                                product.ProductPrice = PriceInput1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                        } while (true);


                        Collection.Add(product);
                        Console.WriteLine("Product has been successfully updated");
                        break;
                    }
                }
            }
        }

        public Product ShallowCopy()
        {
            return (Product)this.MemberwiseClone();
        }

        internal void DeleteProduct(Product product)
        {
            Console.WriteLine("Enter a product id");
            string UserProductId = Console.ReadLine();
            if (ProductIdValidation(UserProductId))
            {
                int UserProductId2 = int.Parse(UserProductId);
                product.ProductId = UserProductId2;
                if (Collection.Remove(product))
                {
                    Console.WriteLine("success");
                }
                else
                {
                    Console.WriteLine("Product does not exits");
                }

            }
        }

        internal void ShowAllIncludedAndDeleted(Product product)
        {
            Console.Write("{0,-15}", "ProductName");
            Console.Write("{0,-15}", "ProductId");
            Console.Write("{0,-15}", "ProductPrice");
            Console.Write("{0,-25}", "StartTime");
            Console.Write("{0,-15}", "EndTime");

            Console.WriteLine();
            Console.WriteLine();


            foreach (var item in Collection.Get())
            {
                if (DateTime.Equals(item.EndTime, null))
                {

                    Console.Write("{0,-15}", item.ProductName);
                    Console.Write("{0,-15}", item.ProductId);
                    Console.Write("{0,-15}", item.ProductPrice);
                    Console.Write("{0,-25}", item.StartTime);
                    Console.Write("{0,-15}", item.EndTime);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0,-10}", "(Active)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    bool flag = true;
                    foreach (var item2 in Collection.Get())
                    {
                        if (DateTime.Equals(item2.EndTime, null))
                        {
                            if (item.ProductId == item2.ProductId)
                            {
                                flag = false;

                            }
                        }


                    }
                    if (flag == true)
                    {

                        Console.Write("{0,-15}", item.ProductName);
                        Console.Write("{0,-15}", item.ProductId);
                        Console.Write("{0,-15}", item.ProductPrice);
                        Console.Write("{0,-25}", item.StartTime);
                        Console.Write("{0,-15}", item.EndTime);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-10}", "(InActive)");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal void GetProductHistory(Product product)
        {
            Console.Write("{0,-15}", "ProductName");
            Console.Write("{0,-15}", "ProductId");
            Console.Write("{0,-15}", "ProductPrice");
            Console.Write("{0,-25}", "StartTime");
            Console.Write("{0,-15}", "EndTime");

            Console.WriteLine();
            Console.WriteLine();


            foreach (var item in Collection.Get())
            {
                if (DateTime.Equals(item.EndTime, null))
                {


                    Console.Write("{0,-15}", item.ProductName);
                    Console.Write("{0,-15}", item.ProductId);
                    Console.Write("{0,-15}", item.ProductPrice);
                    Console.Write("{0,-25}", item.StartTime);
                    Console.Write("{0,-15}", item.EndTime);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0,-10}", "(Active)");
                    Console.ForegroundColor = ConsoleColor.White;


                }
                else
                {
                    bool flag = true;
                    foreach (var item2 in Collection.Get())
                    {
                        if (DateTime.Equals(item2.EndTime, null))
                        {

                            if (item.ProductId == item2.ProductId)
                            {
                                flag = false;

                                Console.Write("{0,-15}", item.ProductName);
                                Console.Write("{0,-15}", item.ProductId);
                                Console.Write("{0,-15}", item.ProductPrice);
                                Console.Write("{0,-25}", item.StartTime);
                                Console.Write("{0,-15}", item.EndTime);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("{0,-10}", "(Active)");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        }


                    }
                    if (flag == true)
                    {

                        Console.Write("{0,-15}", item.ProductName);
                        Console.Write("{0,-15}", item.ProductId);
                        Console.Write("{0,-15}", item.ProductPrice);
                        Console.Write("{0,-25}", item.StartTime);
                        Console.Write("{0,-15}", item.EndTime);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,-10}", "InActive");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal void GetProductDetailsOnDate(Product product)
        {
            Console.WriteLine("Enter a product id");
            string UserProductId = Console.ReadLine();
            Console.WriteLine("Enter a Date");
            string Dateinput = Console.ReadLine();
            if (ProductIdValidation(UserProductId))
            {
                int UserProductId2 = int.Parse(UserProductId);
                product.ProductId = UserProductId2;
                DateTime Dateinput2  = DateTime.Parse(Dateinput);
                foreach (var item2 in Collection.Get())
                {
                    if (item2.ProductId == product.ProductId)
                    {
                        Console.Write("{0,-15}", "ProductName");
                        Console.Write("{0,-15}", "ProductId");
                        Console.Write("{0,-15}", "ProductPrice");
                        Console.Write("{0,-25}", "StartTime");
                        Console.Write("{0,-15}", "EndTime");

                        Console.WriteLine();
                        Console.WriteLine();


                        if (DateTime.Equals(item2.EndTime, Dateinput2) || DateTime.Equals(item2.StartTime, Dateinput2))
                        {
                            Console.Write("{0,-15}", item2.ProductName);
                            Console.Write("{0,-15}", item2.ProductId);
                            Console.Write("{0,-15}", item2.ProductPrice);
                            Console.Write("{0,-25}", item2.StartTime);
                            Console.Write("{0,-15}", item2.EndTime);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("{0,-10}", "(Active)");
                            Console.ForegroundColor = ConsoleColor.White;


                        }
                        else
                        {
                            Console.WriteLine("No product to show on this date");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid product id");
                    }
                }
            }
        }

        
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Product.ProductIdList.Add(0);
            //User.ReadFromFile();
            bool LogedInFlag = false;
            bool AccessFlag = false;

            do
            {
                
                Product product = new Product();
                
                User user = new User();
                Product.ProductIdList.Add(10);
                Collection.WriteToFileForProductId();
                do
                {
                    if (LogedInFlag == false)
                    {
                        user = User.ReadFromFileForSession();
                        if (user.Login == true)
                        {
                            //Console.WriteLine("user1.login is success");

                            if (user.IsAdmin == true)
                            {
                                //Console.WriteLine("admin check is success");
                                AccessFlag = true;
                                LogedInFlag = true;
                                Console.WriteLine("{0,65}", "Welcome To KuchTo");
                                Console.WriteLine("{0,54} {1}", "Hi", user.UserName);
                                Console.WriteLine();


                            }
                            else
                            {
                                AccessFlag = false;
                                LogedInFlag = true;
                                Console.WriteLine("{0,65}", "Welcome To KuchTo");
                                Console.WriteLine("{0,54} {1}", "Hi", user.UserName);
                                Console.WriteLine();
                            }
                            Console.WriteLine("Press any key to Continue");
                            string Value = Console.ReadLine();
                            if (Value.Length >= 1)
                            {
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Welcome To KuchTo");
                            Console.WriteLine();

                            Console.WriteLine("Please Verify your id");
                            Console.WriteLine("Enter your Username");
                            string UserNameInput = Console.ReadLine();
                            if (user.UserNameValidation(UserNameInput))
                            {
                                Console.WriteLine("Enter your Password");
                                string PasswordInput = Console.ReadLine();
                                if (user.PasswordValidation(PasswordInput))
                                {
                                    user.UserName = UserNameInput;
                                    user.Password = PasswordInput;
                                    if (user.IsAdminValidation(UserNameInput, PasswordInput))
                                    {
                                        AccessFlag = true;
                                        user.Login = true;
                                        user.IsAdmin = true;
                                        User.WriteToFileForSession(user);

                                    }
                                    else
                                    {
                                        user.IsAdmin = false;
                                        user.Login = true;
                                        User.WriteToFileForSession(user);
                                    }

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Username or Password");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Username or Password");
                            }
                        }
                    }
                    else
                    {
                        break;
                    }


                } while (true);



                product.StartTime = DateTime.Now.Date;
                Console.WriteLine("Select the following option");
                Console.WriteLine("Option 1 = Show all");
                Console.WriteLine("Option 2 = Add new product");
                Console.WriteLine("Option 3 = Update a product");
                Console.WriteLine("Option 4 = Delete a product");
                Console.WriteLine("Option 5 = Show all included and deleted");
                Console.WriteLine("Option 6 = Get product history");

                if (AccessFlag == true)
                {
                    Console.WriteLine("Option 7 = Create User");
                    Console.WriteLine("Option 8 = Logout");

                    Console.WriteLine("Option 9 = GetProductDetailsOnDate");
                    Console.WriteLine("Option 10 = SaveAllChanges");
                    string ChoiceInput1 = Console.ReadLine();
                    if (ChoiceInput1 == "10")
                    {
                        Collection.WriteToFile();
                        Collection.WriteToFileForProductId();
                    }
                    else if (product.ChoiceInputValidation(ChoiceInput1))
                    {
                        char ChoiceInput2 = char.Parse(ChoiceInput1);

                        if (ChoiceInput2 == '1')
                        {
                            product.ShowAll();
                        }
                        else if(ChoiceInput2 == '2')
                        {
                            product.AddNewProduct(product);
                        }
                        else if(ChoiceInput2 == '3')
                        {
                            product.UpdateProduct(product);
                        }
                        else if(ChoiceInput2 == '4')
                        {
                            product.DeleteProduct(product);
                        }
                        else if(ChoiceInput2 == '5')
                        {
                            product.ShowAllIncludedAndDeleted(product);
                        }
                        else if(ChoiceInput2 == '6')
                        {
                            product.GetProductHistory(product);
                        }
                        else if(ChoiceInput2 == '7')
                        {
                            User.CreateUser(user);
                            User.ReadFromFile();
                        }
                        else if(ChoiceInput2 == '8')
                        {
                            user.Logout(user);
                        }
                        else if(ChoiceInput2 == '9')
                        {
                            product.GetProductDetailsOnDate(product);
                        }
                        continue;
                        
                    }
                }
                else
                {
                    Console.WriteLine("Option 7 = Logout");

                    Console.WriteLine("Option 8 = GetProductDetailsOnDate");

                    string ChoiceInput1 = Console.ReadLine();
                    if (product.ChoiceInputValidation(ChoiceInput1))
                    {
                        char ChoiceInput2 = char.Parse(ChoiceInput1);
                        if (ChoiceInput2 == '1')
                        {
                            product.ShowAll();
                        }
                        if (ChoiceInput2 == '2')
                        {
                            product.AddNewProduct(product);
                        }
                        if (ChoiceInput2 == '3')
                        {
                            product.UpdateProduct(product);
                        }
                        if (ChoiceInput2 == '4')
                        {
                            product.DeleteProduct(product);
                        }
                        if (ChoiceInput2 == '5')
                        {
                            product.ShowAllIncludedAndDeleted(product);
                        }
                        if (ChoiceInput2 == '6')
                        {
                            product.GetProductHistory(product);
                        }
                        if (ChoiceInput2 == '7')
                        {
                            user.Logout(user);
                        }
                        if (ChoiceInput2 == '8')
                        {
                            product.GetProductDetailsOnDate(product);
                        }
                        continue;
                    }

                }
                
            } while (true);


        }
    }

    [Serializable]
    public class User
    {
        public static List<User> users = new List<User>();

        public static List<User> LoginList = new List<User>();
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool Login { get; set; }
        internal bool IsAdminValidation(string userNameInput, string passwordInput)
        {
            foreach (var user in User.ReadFromFile())
            {
                if (user.Password == passwordInput && user.UserName == userNameInput && user.IsAdmin == true)
                {
                    return true;
                }
            }

            return false;
        }

        internal bool PasswordValidation(string passwordInput)
        {
            foreach (var user in User.ReadFromFile())
            {
                if (user.Password == passwordInput) return true;
            }

            return false;
        }

        internal bool UserNameValidation(string userNameInput)
        {
            foreach (var user in User.ReadFromFile())
            {
                if (user.UserName == userNameInput) return true;
            }

            return false;
        }

        internal static void WriteToFile(List<User> userlist)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\file.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, userlist);
            stream.Close();
        }

        internal static void WriteToFileForSession(User userobject)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\session.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, userobject);
            stream.Close();
        }

        internal static List<User> ReadFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\file.txt", FileMode.Open, FileAccess.Read);
            List<User> User1List = (List<User>)formatter.Deserialize(stream);

            stream.Close();
            /*
            foreach(var item in User1List)
            {
                Console.WriteLine(item.UserName);
                Console.WriteLine(item.Password);
                Console.WriteLine(item.IsAdmin);
            }*/
            return User1List;
        }


        internal static User ReadFromFileForSession()
        {
            IFormatter formatter = new BinaryFormatter();
            if (File.Exists("C:\\Users\\Vishal.Khetavat\\Desktop\\session.txt"))
            {
                Stream stream = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\session.txt", FileMode.Open, FileAccess.Read);
                User UserObject = (User)formatter.Deserialize(stream);

                stream.Close();

                return UserObject;
            }
            else
            {
                User EmptyObject = new User();
                return EmptyObject;
            }


        }
        internal static bool CreateUser(User user)
        {
            do
            {
                Console.WriteLine("Enter a New UserName");
                string UserNameInput = Console.ReadLine();
                if (Product.ProductNameValidation(UserNameInput))
                {
                    user.UserName = UserNameInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (true);

            do
            {
                Console.WriteLine("Enter a New Password");
                string PasswordInput = Console.ReadLine();
                Console.WriteLine("Confirm New Password");
                string NewPasswordInput = Console.ReadLine();
                if (PasswordInput == NewPasswordInput)
                {
                    user.Password = PasswordInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Password Not Match");
                }
            } while (true);

            do
            {
                Console.WriteLine("Enter true to provide admin access or enter false");
                string IsAdminInput = Console.ReadLine();

                if (Product.ProductNameValidation(IsAdminInput))
                {
                    user.IsAdmin = Convert.ToBoolean(IsAdminInput);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            } while (true);

            List<User> users1 = ReadFromFile();

            users1.Add(user);
            WriteToFile(users1);
            return true;
        }

        internal void Logout(User userobject)
        {
            userobject = ReadFromFileForSession();
            userobject.Login = false;
            WriteToFileForSession(userobject);
            Console.WriteLine("logout Successfully");

        }
    }
}
