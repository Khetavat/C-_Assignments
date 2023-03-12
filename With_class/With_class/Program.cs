using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace With_class
{
    public sealed class Operation
    {
        public void Execute(int data, Abstract1 obj)
        {
            Console.WriteLine(data);
            for (int i = 0; i <10; i++){
                obj.DoSomething(i);
            }
            Console.WriteLine(data + data);
        }
    }
    public class Abstract1
    {
        public virtual void DoSomething(int i)
        {

        }
    }
    public class PrintOdd : Abstract1
    {
        public int Value { get; set; } = 10;

        public void display()
        {
            Operation operation = new Operation();
            Console.WriteLine("Odd Numbers");
            operation.Execute(Value, this);
        }
        public override void DoSomething(int i)
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
            Console.WriteLine("Even Numbers");
            operation.Execute(Value, this);
        }
        public override void DoSomething(int i)
        {
            
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintEven printEven = new PrintEven();
            printEven.display();

            PrintOdd printOdd = new PrintOdd();
            printOdd.display();

            Console.ReadLine();
        }
    }
}
