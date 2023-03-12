using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 class curtomer ( object nhi banega ) (base)
string name
str location
DOB
double discount(0-100 value)

class gold,silver,platinum (derived) (iska hi instance )

class gold 
dis = 20 ( by default )

class silver
dis = 40 ( by default )

class platinum
dis = 50 ( by default )

menu = enter name,location,DOB(phase2),discount (validation)(repetation)
	type of customer:
		1) silver
		2) gold
		3) platinum ( abhi object banega) ( ek hi collection mai )

last mai display function
one for loop
*/

namespace Customer
{
    abstract class Customer
    {
        public string CustomerName;
        public string CustomerLocation;
        public DateTime DateOfBirth;
        public double Discount;
     

        public static bool CustomerNameValidation(string CustomerNameInput)
        {
            if(CustomerNameInput == null) {
                return false;
            }
            foreach (char c in CustomerNameInput)
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

        public static bool CustomerLocationValidation(string CustomerLocationInput)
        {
            if (CustomerLocationInput == null)
            {
                return false;
            }
            foreach (char c in CustomerLocationInput)
            {
                if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c == ' ' || c >= 0 && c <= 9)
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool DateOfBirthValidation(string manufacturingdate)
        {

            if (DateTime.TryParse(manufacturingdate, out DateTime newmanufacturingdate))
            {
                if (DateTime.Now.Date >= newmanufacturingdate.Date && DateTime.Now.Year >= newmanufacturingdate.Year)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        internal static void Display(List<Customer> list1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 40; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0,-20}", "CustomerName");
            Console.Write("{0,-20}", "CustomerLocation");
            Console.Write("{0,-20}", "Date Of Birth");
            Console.Write("{0,-20}", "Discount");

            Console.WriteLine();
      

            Console.ForegroundColor = ConsoleColor.White;

            foreach (Customer customer in list1)
            {
                Console.Write("{0,-20}", customer.CustomerName);
                Console.Write("{0,-20}", customer.CustomerLocation);
                string DateOfBirthString = Convert.ToString(customer.DateOfBirth);
                Console.Write("{0,-20}", DateOfBirthString.Substring(0,11));
                Console.Write("{0,-20}", customer.Discount);
                Console.WriteLine();
            }

            
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 40; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();

            
        }
    }

    class Gold : Customer
    {

        public Gold()
        {
            Discount = 20;
        }
    }

    class Silver : Customer
    {

        public Silver()
        {
            Discount = 40;
        }
    }

    class Platinum : Customer
    {

        public Platinum()
        {
            Discount = 50;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> list = InputFromUser();

            Customer.Display(list);

            Console.ReadLine();


        }

        private static List<Customer> InputFromUser()
        {
            List<Customer> list1 = new List<Customer>();
            string CustomerNameInput;
            string CustomerLocationInput;
            DateTime DateOfBirthInput;
            double DiscountInput;

            do
            {
                do
                {
                    Console.WriteLine("Enter a Customer Name");
                    CustomerNameInput = Console.ReadLine();
                    if (Customer.CustomerNameValidation(CustomerNameInput))
                    {
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                } while (true);

                do
                {
                    Console.WriteLine("Enter a Customer Location ");
                    CustomerLocationInput = Console.ReadLine();
                    if (Customer.CustomerNameValidation(CustomerLocationInput))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                } while (true);


                do
                {
                    Console.WriteLine("Enter a Date Of Birth ");
                    string value = Console.ReadLine();
                    if (Customer.DateOfBirthValidation(value))
                    {
                        DateOfBirthInput = DateTime.Parse(value);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                } while (true);



                do
                {
                    Dictionary<char,Customer> CharObjectsPairs = new Dictionary<char,Customer>();

                    Gold gold = new Gold();
                    Silver silver = new Silver();
                    Platinum platinum = new Platinum();

                    CharObjectsPairs['1'] = gold;
                    CharObjectsPairs['2'] = silver;
                    CharObjectsPairs['3'] = platinum;   
                    Console.WriteLine("Type of Customer ");

                    Console.WriteLine("Option 1 = Gold");
                    Console.WriteLine("Option 2 = Silver");
                    Console.WriteLine("Option 3 = Platinum");

                    Console.WriteLine("press 1 for Gold, 2 for Silver, 3 for Platinum");
                    bool flag = false;
                    char UserChoice;
                    if(char.TryParse(Console.ReadLine(), out UserChoice))
                    {
                        var Objects = CharObjectsPairs[UserChoice];
                        Objects.CustomerName = CustomerNameInput;
                        Objects.CustomerLocation = CustomerLocationInput;
                        Objects.DateOfBirth = DateOfBirthInput;
                        
                        
                        
                        list1.Add(Objects);
                        break;
                        /*
                        switch (UserChoice)
                        {
                            case '1':
                                Gold gold = new Gold();
                                gold.CustomerName = CustomerNameInput;
                                gold.CustomerLocation = CustomerLocationInput;
                                gold.DateOfBirth = DateOfBirthInput;
                                if (DiscountInput == 0)
                                {

                                }
                                else
                                {
                                    gold.Discount = DiscountInput;
                                }
                                list1.Add(gold);
                                flag = true;
                                break;
                            case '2':
                                Silver silver = new Silver();
                                silver.CustomerName = CustomerNameInput;
                                silver.CustomerLocation = CustomerLocationInput;
                                silver.DateOfBirth = DateOfBirthInput;
                                if (DiscountInput == 0)
                                {

                                }
                                else
                                {
                                    silver.Discount = DiscountInput;
                                }
                                
                                list1.Add(silver);
                                flag = true;
                                break;
                            case '3':
                                Platinum platinum = new Platinum();
                                platinum.CustomerName = CustomerNameInput;
                                platinum.CustomerLocation = CustomerLocationInput;
                                platinum.DateOfBirth = DateOfBirthInput;
                                if (DiscountInput == 0)
                                {

                                }
                                else
                                {
                                    platinum.Discount = DiscountInput;
                                }
                                
                                list1.Add(platinum);
                                flag = true;
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }*/
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");

                    }
                    if(flag == true)
                    {
                        break;
                    }
                } while (true);

                Console.WriteLine();

                Console.WriteLine("Do you want to add more data or exit (press n for exit and Ener to add more data ");


                if (char.TryParse(Console.ReadLine(), out char Decision))
                {
                    if (Decision == 'n')
                    {
                        break;
                    }
                }
            } while (true);



            return list1;
           
        }
    }
}
