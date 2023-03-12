using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier
{
    class Supplier
    {
        public string Address;
        public string Username;
        public string Password;

    }
    class DataContainer
    {
        public List<User> userList = new List<User>();
        

        public bool Validate(Supplier supplier)
        {

            foreach (User item in userList)
            {
                if (supplier.Username == item.Username && supplier.Password == item.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class User
    {
        public string Username;
        public string Password;


    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContainer dataContainer1 = new DataContainer();

            User user1 = new User();
            user1.Username = "test";
            user1.Password = "password";
            dataContainer1.userList.Add(user1);

            User user2 = new User();
            user2.Username = "admin";
            user2.Password = "admin";
            dataContainer1.userList.Add(user2);

            User user3 = new User();
            user3.Username = "user";
            user3.Password = "pass";
            dataContainer1.userList.Add(user3);


            Supplier supplier1 = new Supplier();
            Console.WriteLine("Enter a Address ");
            string address = Console.ReadLine();
            supplier1.Address = address;

            Console.WriteLine("Enter a Username ");
            string username = Console.ReadLine();
            supplier1.Username = username;

            Console.WriteLine("Enter a Password ");
            string password = Console.ReadLine();
            supplier1.Password = password;

            bool result = dataContainer1.Validate(supplier1);
            Console.WriteLine(result);

            Console.ReadLine();



        }
    }
}

