using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Cell = DocumentFormat.OpenXml.Spreadsheet.Cell;

namespace Product_phase2
{
    class DataContainer
    {

        public List<int> BrandIdList { get; set; } = new List<int>();

        public Dictionary<int, string> keyValueMonth = new Dictionary<int, string>();

        public List<Product> list = new list<Product>();

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
        public string ManufacturingDate;
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
                DateTime val = DateTime.Parse(ManufacturingDate);
                if (DateTime.Now > val.AddMonths(6))
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
                DateTime val = DateTime.Parse(ManufacturingDate);
                return val.Year;
            }
        }
        public string ManufacturingMonth
        {

            get
            {
                DateTime val = DateTime.Parse(ManufacturingDate);
                return dataContainer1.keyValueMonth[val.Month];
            }
        }
        public string ExpiringDate
        {
            get
            {
                DateTime val = DateTime.Parse(ManufacturingDate);
                string val2 = Convert.ToString(val.AddMonths(6));
                return val2;
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
                    foreach (Product item in dataContainer3.list)
                    {
                        if (item.ProductId == ProductIdInput)
                        {
                            dataContainer3.list.Remove(item);
                            break;
                        }
                    }
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
                            product2.ManufacturingDate = ManufacturingDateInput;
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

                    foreach (Product item in dataContainer3.list)
                    {
                        if (item.ProductId == ProductIdInput2)
                        {
                            item.BrandId = product2.BrandId;
                            item.ManufacturingDate = product2.ManufacturingDate;
                            item.ProductName = product2.ProductName;
                            break;
                        }
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
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 30; i++)
            {
                Console.Write("♥ ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("ManufacturingDate   ");
            Console.Write("BrandId  ");
            Console.Write("ProductName      ");
            Console.Write("IsExpire   ");
            Console.Write("Manufacturing Year  ");
            Console.Write("Manufacturing Month  ");
            Console.Write("Expiring Date");
            Console.WriteLine();
            Console.WriteLine();
            foreach (Product item in dataContainer4.list)
            {


                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("ProductId {0}", (item.ProductId));
                DateTime val = DateTime.Parse(item.ManufacturingDate);
                string ManufacturingDateInstring = Convert.ToString(val);
                Console.Write(ManufacturingDateInstring.Substring(0, 11));
                Console.Write("         " + item.BrandId);
                if (item.ProductName.Length <= 5)
                {
                    Console.Write("       " + item.ProductName);
                }
                else if (item.ProductName.Length <= 10)
                {
                    Console.Write("     " + item.ProductName);
                }
                else
                {
                    Console.Write("    " + item.ProductName.Substring(0, 7) + "...");
                }

                //Console.Write(" " + item.ProductId);


                if (item.IsExpire)
                {
                    Console.Write("            " + "Expire");
                }
                else
                {
                    Console.Write("       " + "not Expire");
                }

                int Res1 = item.ManufacturingYear;
                Console.Write("          " + Res1);

                string Res2 = item.ManufacturingMonth;
                Console.Write("           " + Res2);

                string Res3 = item.ExpiringDate;
                //Console.Write("              " + Res3.ToString("dd/MM/yyyy"));
                Console.Write("              " + Res3.Substring(0, 11));

                Console.WriteLine();


            }
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
        private List<Product> GetDataFromExcel()
        {
            var xmlFile = Path.Combine(Environment.CurrentDirectory, "C:\\Users\\Vishal.Khetavat\\Documents\\demo.xlsx");
            using (var workBook = new XLWorkbook(xmlFile))
            {
                var workSheet = workBook.Worksheet(1);
                var firstRowUsed = workSheet.FirstRowUsed();
                var firstPossibleAddress = workSheet.Row(firstRowUsed.RowNumber()).FirstCell().Address;
                var lastPossibleAddress = workSheet.LastCellUsed().Address;

                // Get a range with the remainder of the worksheet data (the range used)
                var range = workSheet.Range(firstPossibleAddress, lastPossibleAddress).AsRange(); //.RangeUsed();
                                                                                                  // Treat the range as a table (to be able to use the column names)
                var table = range.AsTable();

                //Specify what are all the Columns you need to get from Excel
                var dataList = new List<string[]>
                 {
                     table.DataRange.Rows()
                         .Select(tableRow =>
                             tableRow.Field("Name")
                                 .GetString())
                         .ToArray(),
                     table.DataRange.Rows()
                         .Select(tableRow => tableRow.Field("Price").GetString())
                         .ToArray(),
                     table.DataRange.Rows()
                     .Select(tableRow => tableRow.Field("age").GetString())
                     .ToArray()
                 };


                //Convert List to DataTable
                var listdata = ConvertListToDataTable(dataList);
                return listdata;
                //To get unique column values, to avoid duplication
                //var uniqueCols = dataTable.DefaultView.ToTable(true, "Name");

                //Remove Empty Rows or any specify rows as per your requirement
                /*
                for (var i = uniqueCols.Rows.Count - 1; i >= 0; i--)
                {
                    var dr = uniqueCols.Rows[i];
                    if (dr != null && ((string)dr["Name"] == "None" || (string)dr["Title"] == ""))
                        dr.Delete();
                }
                Console.WriteLine("Total number of unique solution number in Excel : " + uniqueCols.Rows.Count);*/
            }
        }
        private static List<Product> ConvertListToDataTable(IReadOnlyList<string[]> list)
        {

            var list2 = new List<Product>();

            //var table = new DataTable("CustomTable");
            var rows = list.Select(array => array.Length).Concat(new[] { 0 }).Max();


            for (var j = 0; j < rows; j++)
            {
                var obj = new Product();

                //obj.Bra = Convert.ToDateTime(list[0][j]);
                obj.BrandId = int.Parse(list[0][j]);
                obj.ProductName = list[1][j];
                obj.ProductId = Convert.ToInt32(list[2][j]);
                list2.Add(obj);

            }
            return list2;
        }
        static void Main(string[] args)
        {

            bool flag = true;
            do
            {
                DataContainer datacontainer2 = new DataContainer();
                Product product1 = new Product();
                Console.WriteLine("Option 1 = Import From Excel");
                Console.WriteLine("Option 2 = Enter Manually");
                string Choice2 = Console.ReadLine();
                char choice3 = char.Parse(Choice2);
                if (choice3 == '1')
                {
                    List<Product> DisplayList = ImportFromExcel();
                    foreach(var item in DisplayList)
                    {
                        /*
                        Console.WriteLine(item.ManufacturingYear);
                        Console.WriteLine(item.ProductName);
                        Console.WriteLine(item.ProductId);
                        Console.WriteLine(item.BrandId);*/
                        DataContainer dataContainer6 = new DataContainer();
                        dataContainer6.list.Add(item);
                        product1.Display(dataContainer6);
                    }

                }
                else
                {
                    
                    do
                    {
                        Console.WriteLine("Enter a ManufacturingDate ");
                        string ManufacturingDateInput = Console.ReadLine();
                        bool Result = product1.ManufacturingDateValidation(ManufacturingDateInput);
                        if (Result)
                        {
                            //product1.ManufacturingDate = Convert.ToDateTime(ManufacturingDateInput);
                            product1.ManufacturingDate = ManufacturingDateInput;
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
                }
                



                datacontainer2.list.Add(product1);

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
                            else if (Decision2 == 4)
                            {
                                Console.WriteLine("Exporting data to Excel............");
                                new Program().Export(datacontainer2.list, "C:\\Users\\Vishal.Khetavat\\Documents\\demo3.xlsx", "Products");
                                Console.WriteLine("list has been exported to excel ") ;
                            }

                        } while (true);



                    }
                }


            } while (flag == true);




            Console.ReadLine();


        }

        private static List<Product> ImportFromExcel()
        {
            List<Product> products = new List<Product>();
            try
            {
                //specify the file name where its actually exist   
                string filepath = @"C:\Users\Vishal.Khetavat\Documents\demo3.xlsx";

                //open the excel using openxml sdk  
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filepath, false))
                {
                    //create the object for workbook part  
                    WorkbookPart wbPart = doc.WorkbookPart;
                    //statement to get the count of the worksheet  
                    int worksheetcount = doc.WorkbookPart.Workbook.Sheets.Count();

                    //statement to get the sheet object  
                    Sheet mysheet = (Sheet)doc.WorkbookPart.Workbook.Sheets.ChildElements.GetItem(0);

                    //statement to get the worksheet object by using the sheet id  
                    Worksheet Worksheet = ((WorksheetPart)wbPart.GetPartById(mysheet.Id)).Worksheet;

                    //Note: worksheet has 8 children and the first child[1] = sheetviewdimension,....child[4]=sheetdata  
                    int wkschildno = 4;

                    //statement to get the sheetdata which contains the rows and cell in table  
                    SheetData Rows = (SheetData)Worksheet.ChildElements.GetItem(wkschildno);

                    for (int i = 1; i < Rows.Count(); i++)
                    {
                        Row currentrow = (Row)Rows.ChildElements.GetItem(i);

                        Product p = GetProductFromRow(currentrow, wbPart);
                        products.Add(p);
                    }
                }
            }
            catch (Exception Ex)
            {
                _ = Ex.Message;
            }
            return products;
        }
        private static Product GetProductFromRow(Row currentrow, WorkbookPart wbPart)
        {
            Product product = new Product();
            string manufacturingDateFromExcel = GetCellvalue((Cell)currentrow.ChildElements.GetItem(0), wbPart);
            string productIdFromExcel = ((Cell)currentrow.ChildElements.GetItem(3)).InnerText;
            string productName = GetCellvalue((Cell)currentrow.ChildElements.GetItem(2), wbPart);
            string brandIdFromExcel = ((Cell)currentrow.ChildElements.GetItem(1)).InnerText;
            
            int productId = int.Parse(productIdFromExcel);
            int brandId = int.Parse(brandIdFromExcel);
            //double dateFromExcel = double.Parse(manufacturingDateFromExcel);
            //var date = DateTime.FromOADate(dateFromExcel);
            //DateTime date = DateTime.Parse(manufacturingDateFromExcel);
            //product = new Product();
            //Console.WriteLine(product.ProductName);
            //Console.WriteLine(productName);
            product.ManufacturingDate = manufacturingDateFromExcel;
            product.BrandId = brandId;
            product.ProductName = productName;
            product.ProductId = productId;
            return product;
        }

        private static string GetCellvalue(Cell currentcell, WorkbookPart wbPart)
        {
            string currentcellvalue = string.Empty;
            if (currentcell.DataType != null)
            {
                if (currentcell.DataType == CellValues.SharedString)
                {
                    int id = -1;

                    if (Int32.TryParse(currentcell.InnerText, out id))
                    {
                        SharedStringItem item = GetSharedStringItemById(wbPart, id);

                        if (item.Text != null)
                        {
                            //code to take the string value  
                            currentcellvalue = item.Text.Text;
                        }
                        else if (item.InnerText != null)
                        {
                            currentcellvalue = item.InnerText;
                        }
                        else if (item.InnerXml != null)
                        {
                            currentcellvalue = item.InnerXml;
                        }
                    }
                }
            }
            return currentcellvalue;
        }
        public static SharedStringItem GetSharedStringItemById(WorkbookPart workbookPart, int id)
        {
            return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
        }

        public bool Export(List<Product> list, string file, string sheetname)
        {
            bool exported = false;

            using (IXLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(sheetname).FirstCell().InsertTable<Product>(list, false);

                workbook.SaveAs(file);
                exported = true;
            }
            return exported;
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
