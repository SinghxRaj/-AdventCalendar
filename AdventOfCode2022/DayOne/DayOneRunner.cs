using AdventCalendar.DayOne;

internal class DayOneRunner
{
    private static void Main(string[] args)
    {
        string filePath = @"D:\users\rajvi\repos\Dotnet\Console\C# Fundamentals\C# Console Projects\DayOne\input.txt";
        Console.WriteLine(ElfCalorieParser.CalorieParser(filePath));
        Console.WriteLine(ElfCalorieParser.SumOfTopThree(filePath));
    }
}