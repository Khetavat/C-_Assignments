using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallBack_Even_Odd
{
    public sealed class Operation
    {
        public void Execute(string data,Abstract1 obj)
        {
            Console.WriteLine(data);
            for(int i = 0; i < 10; i++)
            {
                obj.DoSomething(i);
            }
            Console.WriteLine(data + data);
        }
    }
    public abstract class Abstract1
    {
        public abstract void DoSomething(int number);
    }
    public class PrintOdd : Abstract1
    {
        public string Value { get; set; } = "pi";
        public void Display()
        {
            Operation operation = new Operation();
            operation.Execute(Value, this);
        }
        public override void DoSomething(int number)
        {
                if (number % 2 != 0)
                {
                    Console.WriteLine(number);
                }
        }
    }
    public class PrintEven : Abstract1
    {
        public string Value { get; set; } = "even";
        public void Display()
        {
            Operation operation = new Operation();
            operation.Execute(Value, this);
        }
        public override void DoSomething(int number)
        {   
                if (number % 2 == 0)
                {
                    Console.WriteLine(number);
                }
        }
    }

    /*
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
            for(int i = 2;i < number/2; i++)
            {
                if (number % 2 == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public override void DoSomething()
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

    public class PrintStar : Abstract1
    {
        public int Value { get; set; } = 10;

        public void display()
        {
            Operation operation = new Operation();
            operation.Execute(Value, this);
        }

        
        public override void DoSomething()
        {
            for (int i = ; i < Value; i++)
            {
                Console.WriteLine("*");
            }
        }
    }*/
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintOdd printOdd = new PrintOdd();
            printOdd.display();

            PrintEven printEven = new PrintEven();
            printEven.display();

            Console.ReadLine();
        }
    }
}
