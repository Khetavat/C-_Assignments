using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class nonStatic
    {
        // static method can't access using object of non-static class
        public static void display()
        {
            Console.WriteLine("static");
        }

        public void Method()
        {
            Console.WriteLine("non-static");
        }
    }
    static class StaticClass
    {
        public static string variable = "hello";

        //The static constructor of a class is call the first time a static member of the class is accessed.
        static StaticClass()
        {
            Console.WriteLine("Static Constructor");
        }
        public static void StaticMethod()
        {
            Console.WriteLine(variable);
        }

       
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StaticClass.variable = "Hi";
            StaticClass.StaticMethod();
            Console.ReadLine();

        }
    }
}
