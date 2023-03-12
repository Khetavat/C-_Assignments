using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    [Serializable]
    class  Person
    {
        public string Name;
        public int Age;

        internal static bool NameValidation(string nameInput)
        {
            if (nameInput == null)
            {
                return false;
            }
            foreach (char c in nameInput)
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

        internal static bool AgeValidation(string ageInput)
        {
            if (ageInput == null)
            {
                return false;
            }
            foreach (char c in ageInput)
            {
                if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c == ' ')
                {
                    return false;
                }
               
            }
            return true;
        }

        internal static void WriteToFile(List<Person> list4)
        {
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\person.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, list4);
            stream.Close();

        }

        internal static List<Person> ReadFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            if (File.Exists("C:\\Users\\Vishal.Khetavat\\Desktop\\productlist.txt"))
            {
                Stream stream = new FileStream("C:\\Users\\Vishal.Khetavat\\Desktop\\person.txt", FileMode.Open, FileAccess.Read);
                List<Person> User1List = (List<Person>)formatter.Deserialize(stream);

                stream.Close();
              
                return User1List;
            }
            else
            {
                List<Person> ProductList = new List<Person>();
                return ProductList;
            }
        }
    }

    abstract class Operation
    {
        public static void Execute()
        {
            Person person = new Person();
            List<Person> personlist = new List<Person>();
            do
            {
                Console.WriteLine("Select the following options");
                Console.WriteLine("Option 1 = Store Data");
                Console.WriteLine("Option 2 = Display Data");

                Console.WriteLine("press 1 for Store Data, 2 for Display Data");
                string OptionInput = Console.ReadLine();
                if (OptionValidation(OptionInput))
                {
                    char OptionInput2 = char.Parse(OptionInput);
                    if(OptionInput2 == '1')
                    {
                        do
                        {
                            Console.WriteLine("Enter a Name");
                            string NameInput = Console.ReadLine();
                            if (Person.NameValidation(NameInput))
                            {
                                person.Name = NameInput;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                        } while (true);

                        do
                        {
                            Console.WriteLine("Enter a Age");
                            string AgeInput = Console.ReadLine();
                            if (Person.AgeValidation(AgeInput))
                            {
                                int AgeInput2 = int.Parse(AgeInput);
                                person.Age = AgeInput2;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                            }
                        } while (true);

                        personlist.Add(person);

                        Console.WriteLine("Do you want to add more item enter y to continue or n to exits");
                        char Value = char.Parse(Console.ReadLine());
                        if (Value == 'y')
                        {
                            continue;
                        }
                        if (Value == 'n')
                        {
                            break;
                        }

                    }
                    if (OptionInput2 == '2')
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
                      

                        Console.WriteLine();


                        Console.ForegroundColor = ConsoleColor.White;

                        foreach (var item in Person.ReadFromFile())
                        {
                            Console.Write("{0,-20}", item.Name);
                            Console.Write("{0,-20}", item.Age);
                            
                            Console.WriteLine();
                        }


                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i < 40; i++)
                        {
                            Console.Write("* ");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invlid input");
                }


            }while(true);

            Person.WriteToFile(personlist);

        }

        private static bool OptionValidation(string optionInput)
        {
            return true;
        }
    }

    internal class Program
    {


        static void Main(string[] args)
        {
            Operation.Execute();
        }
    }
}
