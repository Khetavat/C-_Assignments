// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information

class Program
{
    
    static void Main()
    {
        bool flag = false;
        do
        {


            Console.WriteLine("Enter a string");
            string string1 = Console.ReadLine();

            do
            {
                Console.WriteLine("Enter a character");

                if (char.TryParse(Console.ReadLine(), out char chr))
                {
                    do
                    {
                        Console.WriteLine("Enter a index in range of 0 to {0}",string1.Length-1);
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            flag = true;
                            for (int i = index; i >= 0; i--)
                            {
                                if (string1[i] == chr)
                                {
                                    Console.WriteLine("String found at index {0}", index - i);
                                    break;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }while(!flag);

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (!flag);
            

            Console.ReadLine();
        } while (!flag);
    }
}


