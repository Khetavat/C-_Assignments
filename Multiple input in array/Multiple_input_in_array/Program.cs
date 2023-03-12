// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main()
    {
        int values;
        Console.WriteLine("How many values you want to add");
        bool check = int.TryParse(Console.ReadLine(), out values);
        int[] array = new int[values];
        for (int i = 0; i < values; i++)
        {
            int number;
            Console.WriteLine("Enter the {0} value", i);
            if (int.TryParse(Console.ReadLine(), out number))
            {
                array[i] = number;
            }
            else
            {
                Console.WriteLine("Invalid input");

            }



        }
        for (int i = 0; i < values; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}
