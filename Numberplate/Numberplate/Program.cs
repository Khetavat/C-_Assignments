// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
class program
{
    static void NumberPlateWithouSpaces(string NumberPlate)
    {
        string sum1 = NumberPlate.Substring(2, 2);
        int sum2 = Convert.ToInt32(sum1);
        int sum3 = 0;

        for (int i = 6; i < NumberPlate.Length; i++)
        {
            int convert = Math.Abs(48 - Convert.ToInt32(NumberPlate[i]));
            
            sum3 += convert;
        }
        if (sum2 == sum3)
        {
            Console.WriteLine("value match");
        }
        else
        {
            Console.WriteLine("value didn't match");
        }
    }


    static void NumberPlateWithouSpacesChar(string NumberPlate)
    {

        string sum1 = NumberPlate.Substring(0, 2);
        int sum2 = 0;
        sum2 += Convert.ToInt32(sum1[0]);
        sum2 += Convert.ToInt32(sum1[1]);
        int sum4 = 0;

        string sum3 = NumberPlate.Substring(4, 2);

        sum4 += Convert.ToInt32(sum3[0]);
        sum4 += Convert.ToInt32(sum3[1]);

        Console.WriteLine(sum2);

        if (sum2 == sum4)
        {
            Console.WriteLine("Char match");
        }
        else
        {
            Console.WriteLine("Char didn't match");
        }
    }

    static void MatchValue(string NumberPlate)
    {
        
     
        int length = 13;
        if (NumberPlate.Length < length)
        {
            NumberPlateWithouSpaces(NumberPlate);
        }
        else
        {
            string sum1 = NumberPlate.Substring(3, 2);
            int sum2 = Convert.ToInt32(sum1);
            int sum3 = 0;

            for (int i = 9; i < NumberPlate.Length; i++)
            {
                int convert = Math.Abs(48 - Convert.ToInt32(NumberPlate[i]));
                
                sum3 += convert;
            }
            if (sum2 == sum3)
            {
                Console.WriteLine("value match");
            }
            else
            {
                Console.WriteLine("value didn't match");
            }
        }
    }

    static void MatchChar(string NumberPlate)
    {
       
        string sum1 = NumberPlate.Substring(0, 2);
        int sum2 = 0;
        sum2 += Convert.ToInt32(sum1[0]);
        sum2 += Convert.ToInt32(sum1[1]);
        int sum4 = 0;

        string sum3 = NumberPlate.Substring(6, 2);
        
        sum4 += Convert.ToInt32(sum3[0]);
        sum4 += Convert.ToInt32(sum3[1]);

        Console.WriteLine(sum2);

        if (sum2 == sum4)
        {
            Console.WriteLine("Char match");
        }
        else
        {
            Console.WriteLine("Char didn't match");
        }
    }
    static void Main()
    {

        Console.WriteLine("Enter a numberplate");
        string NumberPlate = Console.ReadLine();
        int length = 13;
        if (NumberPlate.Length < length)
        {
            NumberPlateWithouSpaces(NumberPlate);
            NumberPlateWithouSpacesChar(NumberPlate);

        }
        else
        {
            MatchValue(NumberPlate);

            MatchChar(NumberPlate);
        }

        Console.ReadLine();
    }


}


