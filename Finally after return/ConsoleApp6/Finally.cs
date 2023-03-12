// See https://aka.ms/new-console-template for more information

internal class Finally
{
    Dictionary<int,string> keyValuePairs= new Dictionary<int,string>();

    public Finally()
    {
        keyValuePairs[1] = "one";
        keyValuePairs[2] = "two";
           
        
    }
    public string Show()
    {
        try
        {
            string Result = keyValuePairs[2];
            Console.WriteLine(Result);
            return Result;
        }
        catch {
            Console.WriteLine("Error");
            return "catch";
        }
        finally
        {
            Console.WriteLine("Finally Block");
            
        }
    }
}