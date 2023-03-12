using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{ 
    class Person
    {
        public string firstname;
        public string lastname;
        public int age;
        public string MobileNumber;
        public string state;

        public List<string> getname(string name)
        {
            string firstname = "";
            string lastname = "";
            string[] array = name.Split(' ');
            List<string> newstring2 = new List<string>();

            foreach (string s in array)
            {
                if(s.Length == 1)
                {
                    
                }
                if (char.TryParse(s,out char char1))
                {
                    continue;
                }
                else
                {
                    newstring2.Add(s);
                }
            }

            return newstring2;
        }

        public int getage(DateTime userdate)
        {
            int Age = 0;
            DateTime now = DateTime.Now;
            int year = now.Year - userdate.Year;
            Age = year;
            return Age;

            //Console.WriteLine(Age);
        }

        public string getnumber(string mobilenumber)
        {
            char[] number = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            if (mobilenumber[0] == '6' && mobilenumber.Length == 10)
            {
                for(int i = 0; i< mobilenumber.Length; i++)
                {
                    if (!number.Contains(mobilenumber[i]))
                    {
                        return "invalid input";
                    }
                }
            }
            else
            {
                return "Invalid input";
            }

            //string.Format("{###}-###-####}", mobmobilenumberile);

       
            string str = string.Format("{0}-{1}-{2}", mobilenumber.Substring(0, 3), mobilenumber.Substring(3, 3), mobilenumber.Substring(6));

            return str;

        }

        public string getstate(string numberplate)
        {
            string res = "";
            Dictionary<string, string> statdictionary = new Dictionary<string, string>();
            statdictionary["MH"] = "Maharashtra";
            statdictionary["GJ"] = "Gujrat";
            statdictionary["UP"] = "Utter Pradesh";

            res = statdictionary[numberplate.Substring(0, 2).ToUpper()];
            return res;


        }

        public override string ToString()
        {
            string String1 = "Name = "+this.firstname+" "+ this.lastname + "Age = " + 
                this.age + "MobilNumber = " + this.MobileNumber + "State = " + this.state ;
           
            return String1;
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new list<Person>();

            bool flag = true;
            do
            {


                Person p = new Person();
                List<string> newstring2 = new List<string>();
                Console.Write("Enter a Name ");
                string name = Console.ReadLine();

                newstring2 = p.getname(name);
                p.firstname = newstring2[0];
                p.lastname = newstring2[1];



                string date = "12-03-2023";
                Console.WriteLine("Enter a date in this format {0} ", date);
                DateTime userdate;
                int result = 0;
                userdate = Convert.ToDateTime(Console.ReadLine());
                result = p.getage(userdate);
                p.age = result;


                do
                {
                    Console.WriteLine("Enter a mobile no");
                    string res = "";
                    string mobilenumber = Console.ReadLine();

                    //string.Format("{###}-###-####}", mobmobilenumberile);
                    res = p.getnumber(mobilenumber);
                    if (res.Length >= 10)
                    {
                        p.MobileNumber = res;
                        Console.WriteLine(res);
                        break;
                    }
                    Console.WriteLine(res);

                } while (true);
                
                Console.ReadLine();

                string res1;
                Console.WriteLine("Enter a numberplate");
                string NumberPlate = Console.ReadLine();
                res1 = p.getstate(NumberPlate);
                p.state = res1;
                
                list.Add(p);

                Console.WriteLine("Do you want to add more y or n");
                string decisioninput = Console.ReadLine();
                char n = '0';
                char.TryParse(decisioninput, out n);

                

                if (n == 'n')
                {
                    flag = false;
                    
                    Console.WriteLine(list);
                    break;
                }

                
                

            } while (flag == true);

            Console.ReadLine();
        }
    }

    
    class list<Person> : List<Person>
    {
        public override string ToString()
        {
            string temp = "";
            foreach(Person p in this)
            {
                
                temp += p.ToString();
            }

            return temp;
        }
    }

}
