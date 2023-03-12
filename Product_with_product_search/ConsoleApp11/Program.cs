using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Product
    {
        public string ProductName;
        public decimal ProductPrice;
        public string Brand;
        public DateTime ManufacturingDate;

        DateTime dateTime1 = DateTime.Now;
        public bool ManufacturingDateValidation(string manufacturingdate)
        {

            if (DateTime.TryParse(manufacturingdate, out DateTime newmanufacturingdate))
            {
                if (dateTime1.Date >= newmanufacturingdate.Date && dateTime1.Year >= newmanufacturingdate.Year)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool BrandValidation(string brand)
        {
            foreach(char c in brand)
            {
                if ( c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c == ' ') { 

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

    }
    class Mobile
    {
        public string MobileName;
        public decimal MobilePrice;
        public string Brand;
        public DateTime MobileManufacturingDate;

        
        public bool IsExpire 
        {
            get
            { 
                if ( DateTime.Now > MobileManufacturingDate.AddMonths(6) ) { 
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public DateTime ExpiringOn 
        {
            get
            {
                return MobileManufacturingDate.AddMonths(6);
            }
        }

        public bool IsExpensive
        {
            get
            {
                if(MobilePrice >= 100000)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
    internal class Program
    {
       
        static void Main(string[] args)
        {
            List<Product> productlist = new List<Product>();
            List<Mobile> mobilelist = new List<Mobile>();

            do
            {
                Product product1 = new Product();

                do
                {
                    Console.WriteLine("Enter a ProductName");
                    string ProductNameInput = Console.ReadLine();
                    if (product1.BrandValidation(ProductNameInput))
                    {
                        product1.ProductName = ProductNameInput;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                } while (true);

                do
                {
                    Console.WriteLine("Enter a ProductPrice");
                    decimal ProductPriceInput;
                    if (decimal.TryParse(Console.ReadLine(), out ProductPriceInput))
                    {
                        product1.ProductPrice = ProductPriceInput;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                } while (true);


                do
                {
                    Console.WriteLine("Enter a BrandName");
                    string BrandNameInput = Console.ReadLine();
                    if (product1.BrandValidation(BrandNameInput))
                    {
                        product1.Brand = BrandNameInput;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                } while (true);


                do
                {
                    Console.WriteLine("Enter a ManufacturingDate ");
                    string ManufacturingDateInput = Console.ReadLine();
                    bool Result = product1.ManufacturingDateValidation(ManufacturingDateInput);
                    if (Result)
                    {
                        product1.ManufacturingDate = Convert.ToDateTime(ManufacturingDateInput);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }

                } while (true);

                productlist.Add(product1);

                Console.WriteLine("Do you want to add another product press y to continue and n to exit");

                if (char.TryParse(Console.ReadLine(), out char Decision))
                {
                    if (Decision == 'n')
                    {
                        mobilelist = FromProduct(productlist);

                        Console.WriteLine("Enter a ProductName you want to display");
                        string Value = Console.ReadLine();
                        bool flag = false;
                        foreach(Mobile item in mobilelist)
                        {
                           
                            if (item.MobileName == Value)
                            {
                                flag = true;
                                Console.ForegroundColor = ConsoleColor.Red;
                                for (int i = 0; i < 30; i++)
                                {
                                    Console.Write("* ");
                                }

                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.WriteLine("Mobile Name = {0} ", item.MobileName);
                                Console.WriteLine("Mobile Price = {0} ", item.MobilePrice);
                                Console.WriteLine("Mobile Brand = {0} ", item.Brand);
                                Console.WriteLine("Mobile ManufacturingDate = {0} ", item.MobileManufacturingDate);
                                if (item.IsExpire)
                                {
                                    Console.WriteLine("Mobile is Expire");
                                }
                                else
                                {
                                    Console.WriteLine("Mobile is Expire");
                                }

                                if (item.IsExpensive)
                                {
                                    Console.WriteLine("Mobile is Expensive");
                                }
                                else
                                {
                                    Console.WriteLine("Mobile is not Expensive");
                                }

                                DateTime Res3 = item.ExpiringOn;
                                Console.WriteLine("Expiring Date = " + Res3.ToString("dd/MM/yyyy"));

                                Console.WriteLine();

                                Console.ForegroundColor = ConsoleColor.Red;
                                for (int i = 0; i < 30; i++)
                                {
                                    Console.Write("* ");
                                }

                                Console.WriteLine();
                            }

                        }
                        if (flag == false)
                        {
                            Console.WriteLine("Product {0} does not exits",Value);
                        }
                        break;
                    }
                } 
            } while (true);


            Console.ReadLine();
            
        }

        private static List<Mobile> FromProduct(List<Product> productlist)
        {
            
            List<Mobile> mobilelist2 = new List<Mobile>();
            foreach (Product item in productlist) {
                Mobile mobile2 = new Mobile();
                mobile2.MobileName = item.ProductName;
                mobile2.MobilePrice = item.ProductPrice;
                mobile2.Brand = item.Brand;
                mobile2.MobileManufacturingDate = item.ManufacturingDate;

                mobilelist2.Add(mobile2);
            }

    

            return mobilelist2;
        }
    }
}
