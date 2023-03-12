// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
class program
{
    static void Main()
    {
        bool flag = false;
        do
        {


            int values;
            Console.WriteLine("Enter the size of pattern");
            bool check = int.TryParse(Console.ReadLine(), out values);

            if (check)
            {

                flag = true;

                int[,] TwoDArray = new int[values, values];

                int row = 0;
                int col = 0;

                int endrow = values;
                int endcol = values;

                int count = 1;
                while (row < endrow && col < endcol)
                {
                    for (int i = col; i < endcol; i++)
                    {
                        TwoDArray[row, i] = count;
                        count += 1;
                    }
                    row += 1;

                    for (int j = row; j < endrow; j++)
                    {
                        TwoDArray[j, endcol - 1] = count;
                        count += 1;
                    }
                    endcol -= 1;

                    for (int k = endcol-1; k >= col; k--)
                    {
                        TwoDArray[endrow-1, k] = count;
                        count += 1;
                    }
                    endrow -= 1;

                    for (int x = endrow-1; x >= row; x--)
                    {
                        TwoDArray[x, col] = count;
                        count += 1;
                    }
                    col += 1;

                }
                for (int y = 0; y < values; y++)
                {
                    for (int z = 0; z < values; z++)
                    {
                        Console.Write(TwoDArray[y, z] + " ");
                    }
                    Console.WriteLine();
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


