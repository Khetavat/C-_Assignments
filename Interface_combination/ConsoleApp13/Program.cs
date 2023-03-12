using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    public interface IPerson
    {
        void GetMyName();
    }

    public interface ISupplier : IPerson
    {
        void Export();
    }

    public interface IDoctor : IPerson
    {
        void Surgery();
    }

    public interface IFather : IPerson
    {
        void EntertaintChild();
    }

     
    

    class DoctorFather : IDoctor
    {
        

        public void GetMyName()
        {
            Console.WriteLine("DoctorFather Class1");
        }

        public void Surgery()
        {
            Console.WriteLine("DoctorFather Class2");
        }
    }

    class PersonSupplier : ISupplier
    {
        public void GetMyName()
        {
            Console.WriteLine("Person");
        }
        public void Export()
        {
            Console.WriteLine("Export method");
        }

    }

    class FatherPerson : IFather
    {
        public void GetMyName()
        {
            Console.WriteLine("FatherPerson Class1");
        }
        public void EntertaintChild()
        {
            Console.WriteLine("FatherPerson Class2");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            
            PersonSupplier p1 = new PersonSupplier();
            OnlyPerson(p1);
            Console.ReadLine();
            
        }
        static void OnlyPerson(IPerson person)
        {
            Console.WriteLine("Iperson only");
            
        }
    }
}
