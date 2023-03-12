// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;

class program
{
    static void Age()
    {

        int year = now.Year - userdate.Year;
        Console.WriteLine("The total Age are {0}", year);
    }
    
    static void TotalDayMonthYear(userdate)
    {
        int year = now.Year - userdate.Year;
        int month = 12 * year + (userdate.Month - now.Month);
        int leapyear = year / 4;
        int day = 365 * year + leapyear;


        Console.WriteLine("The total day's are {0} , month are {1} and year are {2}", day, month, year);
    }
    static void Main()
    {
        DateTime now = DateTime.Today;
        string SystemDate = DateTime.Today.ToString("d-M-yyyy");

        Console.WriteLine("Enter a date");
        DateTime userdate;
        if(DateTime.TryParse(Console.ReadLine(), out userdate)) {

            Age(userdate);
            TotalDayMonthYear(userdate);
        }
        
        
        
        

    }
}

