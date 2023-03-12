// See https://aka.ms/new-console-template for more information

class Program
{
    
   
    static void Main()
    {
        int num = 10;
        object obj = num;
        set(ref obj);
        Console.WriteLine(obj);
        Console.WriteLine(num);

        void set(ref object x)
        {
            x = 20;
            
        }


        Finally finally1 = new Finally();
        Console.WriteLine(finally1.Show());

    }
}
