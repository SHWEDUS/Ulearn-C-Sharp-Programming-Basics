using System.Globalization;

namespace Percents;

internal static class PercentTask
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите исходную сумму, процентую  ставку и срок  вклада в месяцах через пробел");
        var input  = Console.ReadLine();
        if (input != null)
        {
            Console.WriteLine(Calculate(input));
        }
    }
    
    public static double Calculate(string userInput)
    {
        var input = userInput.Split(" ");
        
        var sum = double.Parse(input[0], CultureInfo.InvariantCulture);
        var percent = double.Parse(input[1], CultureInfo.InvariantCulture);
        var period = Int32.Parse(input[2]);
        
        return sum * Math.Pow((1 + percent / (12 * 100)),  period);
    }
}