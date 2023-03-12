// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information

class Program
{
    static bool IsPrime(int number)
    {
        for(int i = 2; i < number/2; i++)
        {
            if(number%2 == 0)
            {
                return false;
            }
        }
        return true;
    }
    static void Main()
    {
       
        Console.WriteLine("Enter the number");
        bool flag = true;
        int value;
        do
        {
            if (int.TryParse(Console.ReadLine(), out value))
            {
                flag = false;
                value = value + 1;
                while (IsPrime(value) == false)
                {
                    value= value + 1;
                }
                Console.WriteLine("The next prime number is {0}",value);

            }
            else
            {
                Console.WriteLine("Invalid input");
            }


        } while (flag == true);

        Console.ReadLine();

    }
}

