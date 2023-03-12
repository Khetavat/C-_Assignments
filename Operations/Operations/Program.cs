using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class Operation
    {
        public virtual void Execute(string Data)
        {
            Console.WriteLine(Data);
            Console.WriteLine("Printing through Printer");
            Console.WriteLine(Data + Data);
        }
    }

    public class Printer : Operation 
    {
        
        public override void Execute(string Data)
        {
    
            Console.WriteLine(Data);
            Console.WriteLine("Printing Through Printer");
            Console.WriteLine(Data + Data);
        }
    }

    public class Scanner : Operation
    {
        public override void Execute(string Data)
        {
            Console.WriteLine(Data);
            Console.WriteLine("Printing Through Scanner");
            Console.WriteLine(Data + Data);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           

            Operation Object = new Scanner();
            Object.Execute("hello");

            Console.ReadLine();
            
            
        }
    }
}
