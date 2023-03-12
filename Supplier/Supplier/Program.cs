using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier
{
    class ForList
    {

    }
    class User
    {
        public string Username;
        public string Password;
    }
    class Supplier
    {
        public List<User> userList2 = new List<User>();

        public string Address;
        public string Username;
        public string Password;

        /*
        public void method(List<string> userList1)
        {
            foreach(User item in userList1)
            {
                userList2.Add(item);
            }
        }*/

        public bool Validate()
        {
            foreach (User item in userList2)
            {
                if (this.Username == item.Username && this.Password == item.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> userList = new List<User>();
            User user1 = new User();
            user1.Username= "test";
            user1.Password= "password";
            userList.Add(user1);

            User user2 = new User();
            user2.Username = "admin";
            user2.Password = "admin";
            userList.Add(user2);

            User user3 = new User();
            user3.Username = "user";
            user3.Password = "pass";
            userList.Add(user3);


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

            supplier1.userList2 = userList;
            bool result = supplier1.Validate();
            Console.WriteLine(result);

            Console.ReadLine();



        }
    }
}
