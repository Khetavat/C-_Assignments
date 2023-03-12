using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_phase2
{
    class DataContainer
    {

        public List<int> BrandIdList { get; set; } = new List<int>();

        public Dictionary<int, string> keyValueMonth = new Dictionary<int, string>();

        public Dictionary<int, Product> IdProductPairs = new Dictionary<int, Product>();

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

        public int ProductId;

        DataContainer dataContainer1 = new DataContainer();
        DateTime dateTime1 = DateTime.Now;

        Random random1 = new Random();
        public Product()
        {
            this.ProductId = random1.Next(10000, 99999);
        }


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
                if (DateTime.Now > ManufacturingDate.AddMonths(6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                /*
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
                }*/
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


        public int Menu(DataContainer dataContainer3)
        {

            Console.WriteLine("Menu");
            Console.WriteLine("Option 1 : Delete a product");
            Console.WriteLine("Option 2 : Update a product");
            Console.WriteLine("Option 3 : Exist");
            Console.WriteLine("Option 4 : Export to Excel");
            Console.WriteLine("Type 1,2,3 ");

            string Option;

            Option = Console.ReadLine();
            switch (Option)
            {
                case "1":
                    Console.WriteLine("Enter a ProductId");
                    int ProductIdInput = Convert.ToInt32(Console.ReadLine());
                    Product newproduct = dataContainer3.IdProductPairs[ProductIdInput];
                    dataContainer3.IdProductPairs.Remove(ProductIdInput);
                    return 1;
                case "2":
                    Console.WriteLine("Enter a ProductId");
                    int ProductIdInput2 = Convert.ToInt32(Console.ReadLine());
                    Product product2 = new Product();
                    do
                    {
                        Console.WriteLine("Enter a new ManufacturingDate ");
                        string ManufacturingDateInput = Console.ReadLine();
                        bool Result = ManufacturingDateValidation(ManufacturingDateInput);
                        if (Result)
                        {
                            product2.ManufacturingDate = Convert.ToDateTime(ManufacturingDateInput);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }

                    } while (true);

                    do
                    {
                        Console.WriteLine("Enter a new BranId");
                        if (int.TryParse(Console.ReadLine(), out int BranIdinput))
                        {
                            if (BrandIdValidation(BranIdinput))
                            {
                                product2.BrandId = BranIdinput;
                                break;
                            }

                        }
                        Console.WriteLine("Invalid input");
                    } while (true);

                    do
                    {
                        Console.WriteLine("Enter a new ProductName");
                        string ProductNameInput = Console.ReadLine();
                        if (ProductNameInput.Length <= 100)
                        {
                            product2.ProductName = ProductNameInput;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    } while (true);

                    Product newproduct2 = dataContainer3.IdProductPairs[ProductIdInput2];

                    if (newproduct2.ProductId == ProductIdInput2)
                    {
                        newproduct2.BrandId = product2.BrandId;
                        newproduct2.ManufacturingDate = product2.ManufacturingDate;
                        newproduct2.ProductName = product2.ProductName;
                        
                    }


                    return 2;
                case "3":
                    return 3;
                default:
                    return 4;
            }
        }

        public void Display(DataContainer dataContainer4)
        {
            foreach(var item in dataContainer4.IdProductPairs)
            {
                Console.WriteLine(item.Value.ProductId);
            }

            Console.WriteLine("Enter a ProductId");
            int ProductIdInput3 = Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 30; i++)
            {
                Console.Write("♥ ");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0,-20}","ManufacturingDate");
            Console.Write("{0,-20}", "BrandId  ");
            Console.Write("{0,-20}", "ProductName      ");
            Console.Write("{0,-20}", "IsExpire   ");
            Console.Write("{0,-20}", "Manufacturing Year  ");
            Console.Write("{0,-20}", "Manufacturing Month  ");
            Console.Write("{0,-20}", "Expiring Date");
            Console.WriteLine();
            Console.WriteLine();

            Product ProductDisplay = dataContainer4.IdProductPairs[ProductIdInput3];

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ProductId {0}", (ProductDisplay.ProductId));
            string ManufacturingDateInstring = Convert.ToString(ProductDisplay.ManufacturingDate);
            Console.Write("{0,-20}", ManufacturingDateInstring.Substring(0, 11));
            Console.Write("{0,-20}", ProductDisplay.BrandId);
            if (ProductDisplay.ProductName.Length <= 5)
            {
                Console.Write("{0,-20}", ProductDisplay.ProductName);
            }
            else if (ProductDisplay.ProductName.Length <= 10)
            {
                Console.Write("{0,-20}", ProductDisplay.ProductName);
            }
            else
            {
                Console.Write("{0,-20}", ProductDisplay.ProductName.Substring(0, 7) + "...");
            }

            //Console.Write(" " + item.ProductId);


            if (ProductDisplay.IsExpire)
            {
                Console.Write("{0,-20}", "Expire");
            }
            else
            {
                Console.Write("{0,-20}", "not Expire");
            }

            int Res1 = ProductDisplay.ManufacturingYear;
            Console.Write("{0,-20}", Res1);

            string Res2 = ProductDisplay.ManufacturingMonth;
            Console.Write("{0,-20}",Res2);

            DateTime Res3 = ProductDisplay.ExpiringDate;
            Console.Write("{0,-20}", Res3.ToString("dd/MM/yyyy"));

            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 30; i++)
            {
                Console.Write("♥ ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {


            DataContainer datacontainer2 = new DataContainer();

            bool flag = true;
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



                datacontainer2.IdProductPairs.Add(product1.ProductId, product1);

                Console.WriteLine("Do you want to add another product press y to continue and n to exit");

                if (char.TryParse(Console.ReadLine(), out char Decision))
                {
                    if (Decision == 'n')
                    {

                        
                        product1.Display(datacontainer2);
                        do
                        {
                            int Decision2 = product1.Menu(datacontainer2);
                            if (Decision2 == 1)
                            {
                                // list display
                                
                                product1.Display(datacontainer2);

                            }
                            else if (Decision2 == 3)
                            {
                                flag = false;
                                break;
                            }
                            else if (Decision2 == 2)
                            {
                                Console.WriteLine("Your Product has been updated");
                                Console.WriteLine("Press Enter to Continue ");
                                string Enter = Console.ReadLine();
                                Console.Clear();
                                // list display
                                
                                product1.Display(datacontainer2);


                                Console.ForegroundColor = ConsoleColor.Red;
                                for (int i = 0; i < 30; i++)
                                {
                                    Console.Write("♥ ");
                                }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine();

                            }

                        } while (true);



                    }
                }


            } while (flag == true);




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
