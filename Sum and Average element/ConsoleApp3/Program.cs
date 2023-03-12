// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        int values;
        Console.WriteLine("How many values you want to add");
        bool check = int.TryParse(Console.ReadLine(), out values);

        int[] array = new int[values];
        int i = 0;
        while (i<values)
        {
            int number;
            Console.WriteLine("Enter the {0} value", i+1);
            if (int.TryParse(Console.ReadLine(), out number))
            {
                array[i] = number;
                i += 1;
            }
            else
            {
                Console.WriteLine("Invalid input");
               

            }


        }
        int sumArray = 0;
        int averageArray = 0;
        for (int j = 0; j < values; j++)
        {
            sumArray += array[j];
        }
        averageArray = sumArray / values;
        Console.WriteLine("The sum of array is {0}", sumArray);
        Console.WriteLine("The average of array is {0}", averageArray);
    }
}
