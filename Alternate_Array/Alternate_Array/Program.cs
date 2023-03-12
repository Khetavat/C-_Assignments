// See https://aka.ms/new-console-template for more information
class program
{
    static void Main()
    {
        int values;
        Console.WriteLine("How many values you want to add");
        bool check = int.TryParse(Console.ReadLine(),out values);
        int[] array = new int[values];
        int i = 0;
        while (i<values)
        {
            int number;
            Console.WriteLine("Enter the {0} value", i + 1);
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
        Console.WriteLine("The alternate array is");
        for(int j = 0; j <values; j+=2) {
            Console.WriteLine(array[j]);
        }

    }
}
