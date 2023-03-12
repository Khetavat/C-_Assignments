// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
class program
{
    public static void waitFor1Seconds()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        while (stopwatch.ElapsedMilliseconds < 1000)
        {

        }
        stopwatch.Stop();

    }

    static void Main()
    {
        bool flag = false;
        do
        {


            int values;
            Console.WriteLine("Enter the size of pattern");
            bool check = int.TryParse(Console.ReadLine(), out values);
           
            Console.ForegroundColor= ConsoleColor.Magenta;

            if (check)
            {
                flag = true;
          
                for (int i = 0; i <= values; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write("♥");
                        
                    }
                    Console.WriteLine();
                    waitFor1Seconds();
                    

                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        } while (flag == false);

        
    }
    

}

