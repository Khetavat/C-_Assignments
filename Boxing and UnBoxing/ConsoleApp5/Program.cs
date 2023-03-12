// See https://aka.ms/new-console-template for more information
using System.Collections;
class Program
{
    static void Main()
    {
        //Boxing
        int number = 23;
        object Obj = 10;
        object Obj2 = "vishal";

        //Unboxing
        int anothernumber = (int)Obj;
        Console.WriteLine(anothernumber);

        ArrayList arrayList = new ArrayList();
        arrayList.Add(1);
        arrayList.Add("data");
       
        Console.WriteLine("The sum of arrayList is {0}", (int)arrayList[0]+ (string)arrayList[1]);

        Console.WriteLine(arrayList.Capacity);
        arrayList.Add(1);
        arrayList.Add(2);
        arrayList.Add(1);
        arrayList.Add(2);
        Console.WriteLine(arrayList.Capacity);
        Console.ReadLine();




    }
}