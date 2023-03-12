// See https://aka.ms/new-console-template for more information

// See https://aka.ms/new-console-template for more information
class program
{
    static void Tiplets()
    {
        int values;
        Console.WriteLine("How many values you want to add");
        bool check = int.TryParse(Console.ReadLine(), out values);
        int[] array = new int[values];
        int i = 0;
        while (i < values)
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
        Console.WriteLine("The Triplets of an array are");
        int j = 0;
        int k = 1;
        int l = 2;
        while (j < values && k < values && l < values)
        {
            int val1 = array[j];
            int val2 = array[k];
            int val3 = array[l];
            int val4 = val2 - val1;
            int val5 = val3 - val2;
            if (val4 == 1 && val5 == 1)
            {
                Console.WriteLine("{0},{1},{2}", val1, val2, val3);
            }
            /*
            else if (val3 == -1)
            {
                Console.WriteLine("{0},{1}", val2, val1);

                
            }*/
            j += 1;
            k += 1;
            l += 1;
        }

        static void Prais()
        {
            int values;
            Console.WriteLine("How many values you want to add");
            bool check = int.TryParse(Console.ReadLine(), out values);
            int[] array = new int[values];
            int i = 0;
            while (i < values)
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
            Console.WriteLine("The consecutive pairs of an array are");
            int j = 0;
            int k = 1;
            while (j < values && k < values)
            {
                int val1 = array[j];
                int val2 = array[k];
                int val3 = val2 - val1;
                if (val3 == 1)
                {
                    Console.WriteLine("{0},{1}", val1, val2);
                }
                /*
                else if (val3 == -1)
                {
                    Console.WriteLine("{0},{1}", val2, val1);


                }*/
                j += 1;
                k += 1;
            }
        }
        static void Main()
        {

            Tiplets();

        }
    }
}
