using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_Interface
{
    public sealed class Operation
    {
        public void Execute(int data, Abstract1 obj)
        {
            Console.WriteLine(data);
            for(int i = 0; i < 10; i++)
            {
                obj.DoSomething(i);
            }
            Console.WriteLine(data + data);
        }
    }


    public interface Abstract1
    {
        void DoSomething(int i);
    }

    public class PrintOdd : Abstract1
    {
        public int Value { get; set; } = 10;

        public void display()
        {
            Operation operation = new Operation();
            Console.WriteLine("Printing Odd Number");
            operation.Execute(Value, this);
            
        }
        public  void DoSomething(int i)
        {
         
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            
        }
    }

    public class PrintEven : Abstract1
    {
        public int Value { get; set; } = 10;

        public void display()
        {
            Operation operation = new Operation();
            operation.Execute(Value, this);
        }
        public  void DoSomething(int i)
        {
     
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            
        }
    }

    public class PrimeNo : Abstract1
    {
        public int Value { get; set; } = 10;

        public void display()
        {
            Operation operation = new Operation();
            operation.Execute(Value, this);
        }

        bool isprime(int number)
        {
            for (int i = 2; i < number / 2; i++)
            {
                if (number % 2 == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public  void DoSomething(int i)
        {

            if (isprime(i))
            {
                Console.WriteLine(i);
            }
        }
    }

 
    internal class Program
    {
        static void Main(string[] args)
        {

            PrintOdd printOdd = new PrintOdd();
            printOdd.display();

            Console.ReadLine();
        }
    }
}
