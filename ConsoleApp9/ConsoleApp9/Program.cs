using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class User
    {
        //prop
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class Supplier
    {
        public string Username { get; set; }
        public string Password { get; set; }

        char Gender1;

        public string MyProperty { get; set; } = "hello";
        public string Gender
        {
            get
            {
                if (this.Gender1 == 'M' || this.Gender1 == 'm')
                {
                    return "Male";
                }
                else
                {
                    return "Female";
                }
            }
            
        }

        public char Gender2
        {
            set
            {
                //char value1 = Convert.ToChar(value)
                if (value == 'm' || value == 'M')
                {
                    this.Gender1 = 'M';
                }
                else
                {
                    this.Gender1 = 'F';
                }
            }
        }

        ValidUser validUser1 = new ValidUser();

        DataContainer dataContainer1 = new DataContainer();

        public bool Validate()
        {
            foreach(User item in dataContainer1.List1)
            {
                if (this.Username == item.Username && this.Password == item.Password)
                {
                    return true;
                }
            }
            return false;
            
        }

        /*
        public string ReturnGender()
        {
            if(this.Gender == 'M' || this.Gender == 'm')
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }
        public bool IsLetterSExit()
        {
            if (this.Username.Contains('s'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetGender(char gender)
        {
            
            if (gender == 'M' || gender == 'm')
            {
                this.Gender = 'M';
            }
            else
            {
                this.Gender = 'F';
            }
            
        }*/
}

    class DataContainer
    {
        public List<User> List1 { get; set; } = new List<User>();

        //ctor
        public DataContainer()
        {
            User User1 = new User();
            User1.Username = "test";
            User1.Password = "test";

            List1.Add(User1);

            User User2 = new User();
            User2.Username = "admin";
            User2.Password = "admin";

            List1.Add(User2);
        }
    }

    class ValidUser
    {
        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "123";
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            

            Supplier supplier1 = new Supplier();




            Console.WriteLine("Enter a Username ");
            string username = Console.ReadLine();
            supplier1.Username = username;

            Console.WriteLine("Enter a Password ");
            string password = Console.ReadLine();
            supplier1.Password = password;

            bool result2 = supplier1.Validate();
            if (result2)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }



            supplier1.Gender2 = 'm';
            string result = supplier1.Gender;
            Console.WriteLine(result);

            Console.WriteLine(supplier1.MyProperty);

            Console.ReadLine();

        }
    }
}
