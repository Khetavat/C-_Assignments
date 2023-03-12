using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    class DataContainer
    {

        public List<int> BrandIdList { get; set; } = new List<int>();

        public Dictionary<int, string> keyValueMonth = new Dictionary<int, string>();

        public DataContainer()
        {
            BrandIdList.Add(12345);
            BrandIdList.Add(60001);
            BrandIdList.Add(50001);
            BrandIdList.Add(40001);
            BrandIdList.Add(30001);
            BrandIdList.Add(10001);
            BrandIdList.Add(20001);

            keyValueMonth[1] = "January";
            keyValueMonth[2] = "February";
            keyValueMonth[3] = "March";
            keyValueMonth[4] = "April";
            keyValueMonth[5] = "May";
            keyValueMonth[6] = "June";
            keyValueMonth[7] = "July";
            keyValueMonth[8] = "August";
            keyValueMonth[9] = "September";
            keyValueMonth[10] = "October";
            keyValueMonth[11] = "November";
            keyValueMonth[12] = "December";


        }
    }
    class Product
    {
        public DateTime ManufacturingDate;
        public int BrandId;
        public string ProductName;

        DataContainer dataContainer1 = new DataContainer();
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

        public bool BrandIdValidation(int manufacturingdate)
        {


            if (dataContainer1.BrandIdList.Contains(manufacturingdate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool IsExpire
        {
            get
            {
                int manufacturingmonth;
                int manufacturingyear = dateTime1.Year - ManufacturingDate.Year;
                if (ManufacturingDate.Month > dateTime1.Month && manufacturingyear == 1)
                {
                    manufacturingmonth = dateTime1.Month + (12 - ManufacturingDate.Month);
                    if (manufacturingmonth > 6)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    manufacturingmonth = Math.Abs(dateTime1.Month - ManufacturingDate.Month);
                    if (manufacturingmonth >= 6 || manufacturingyear >= 1)
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

        public int ManufacturingYear
        {
            get
            {
                return ManufacturingDate.Year;
            }
        }
        public string ManufacturingMonth
        {

            get
            {
                return dataContainer1.keyValueMonth[ManufacturingDate.Month];
            }
        }
        public DateTime ExpiringDate
        {
            get
            {
                return ManufacturingDate.AddMonths(6);
            }
        }

        

        internal class Program
        {
            static void Main(string[] args)
            {
                

                List<Product> list = new list<Product>();

                
                do
                {
                    Product product1 = new Product();
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


                    do
                    {
                        Console.WriteLine("Enter a BranId");
                        if (int.TryParse(Console.ReadLine(), out int BranIdinput))
                        {
                            if (product1.BrandIdValidation(BranIdinput))
                            {
                                product1.BrandId = BranIdinput;
                                break;
                            }

                        }
                        Console.WriteLine("Invalid input");
                    } while (true);

                    do
                    {
                        Console.WriteLine("Enter a ProductName");
                        string ProductNameInput = Console.ReadLine();
                        if (ProductNameInput.Length <= 100)
                        {
                            product1.ProductName = ProductNameInput;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    } while (true);

                    

                    list.Add(product1);

                    Console.WriteLine("Do you want to add another product press y to continue and n to exit");

                    if (char.TryParse(Console.ReadLine(), out char Decision))
                    {
                        if (Decision == 'n')
                        {
                            Console.WriteLine(list);
                            
                            foreach(Product item in list)
                            {
                                
                                Console.ForegroundColor = ConsoleColor.Red;
                                for(int i = 0; i < 30; i++)
                                {
                                    Console.Write("♥ ");
                                }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("ManufacturingDate = {0}", item.ManufacturingDate);
                                Console.WriteLine("BrandId = {0}", item.BrandId);
                                Console.WriteLine("ProductName = {0}", item.ProductName);

                                
                                if (item.IsExpire)
                                {
                                    Console.WriteLine("Product Expire");
                                }
                                else
                                {
                                    Console.WriteLine("Product not Expire");
                                }

                                int Res1 = item.ManufacturingYear;
                                Console.WriteLine("The Manufacturing year is {0}", Res1);

                                string Res2 = item.ManufacturingMonth;
                                Console.WriteLine("The Manufacturing month is {0}",Res2);

                                DateTime Res3 = item.ExpiringDate;
                                Console.WriteLine("The Expiring date is {0}", Res3.ToString("dd/MM/yyyy"));

                                Console.ForegroundColor = ConsoleColor.Red;
                                for (int i = 0; i < 30; i++)
                                {
                                    Console.Write("♥ ");
                                }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine();

                            }

                            break;
                        }
                    }


                } while (true);


                Console.ReadLine();


            }
        }
        class list<Product> : List<Product>
        {
            string temp = "";
            public override string ToString()
            {
                foreach (Product item in this)
                {
                    temp += item.ToString();
                }
                return temp;
            }

        }
    }
}
