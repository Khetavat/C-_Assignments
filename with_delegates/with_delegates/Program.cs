using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace with_delegates
{
    public sealed class Operation
    {
        public void Execute(string data,Action<int> action)
        {
            Console.WriteLine(data);
            for(int i = 0; i < 10; i++) { 
                action(i);
            }
            Console.WriteLine(data + data);
        }
    }
    public class PrintOdd
    {
        public int Value { get; set; } = 10;

        public void display()
        {
            Operation operation = new Operation();
            operation.Execute("pi",DoSomething);
        }
        public void DoSomething(int i)
        {
            
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            
        }
    }

    public class PrintEven
    {
        public int Value { get; set; } = 10;

        public void display()
        {
            Operation operation = new Operation();
            operation.Execute("hello",DoSomething);
        }
        public void DoSomething(int i)
        {

                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                    }
    }

    public class PrimeNo
    {
        public int Value { get; set; } = 10;

        public void display()
        {
            Operation operation = new Operation();
            operation.Execute("start",DoSomething);
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
            for (int i = 2; i < Value; i++)
            {
                if (isprime(i))
                {
                    Console.WriteLine(i);
                }

            }
        }
    }

    public class PrintStar
    {
        public int Value { get; set; } = 10;

        public void display()
        {
            Operation operation = new Operation();
            operation.Execute("start",DoSomething);
        }


        public void DoSomething(int i)
        {
            for (int i = 0; i < Value; i++)
            {
                Console.WriteLine("*");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintEven printEven = new PrintEven();
            printEven.display();

            Console.ReadLine();
        }
    }
}
