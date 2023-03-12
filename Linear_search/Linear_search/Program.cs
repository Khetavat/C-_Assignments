// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 4, 5,10, 11, 12, 15};
        Console.WriteLine("Enter the value between 1 to 15 you want to search");
        bool flag = true;
        int value;
        do
        {
            if (int.TryParse(Console.ReadLine(), out value))
            {
                flag = false;
                int i = 0;
                while(i < array.Length)
                {
                    if (value == array[i])
                    {
                        Console.WriteLine("value is present");
                        break;
                    }
                    i ++;
                }
                if (i == array.Length)
                {
                    Console.WriteLine("value is not present");
                }
                
    
            }
            else
            {
                Console.WriteLine("Invalid input");
            }


        }while(flag == true);

        Console.ReadLine();

    }
}
