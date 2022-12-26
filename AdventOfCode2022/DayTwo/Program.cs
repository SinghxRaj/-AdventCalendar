internal class Program
{
    private static void Main(string[] args)
    {
        string inputFile = @"D:\users\rajvi\Repos\Personal-Projects\AdventOfCode2022\DayTwo\input.txt";
        string moveToMoveMapping = @"D:\users\rajvi\Repos\Personal-Projects\AdventOfCode2022\DayTwo\MoveToMove.txt";
        string moveToDecisionMapping = @"D:\users\rajvi\Repos\Personal-Projects\AdventOfCode2022\DayTwo\MoveToDecision.txt";

        Console.WriteLine("Hello, World!");
        var rounds = File.ReadAllLines(inputFile).ToList();
        Console.WriteLine($"Move to Move: {CalculateTotalScore(rounds,  moveToMoveMapping)}");
        Console.WriteLine($"Move to Decision: {CalculateTotalScore(rounds, moveToDecisionMapping)}");
    }

    private static int CalculateTotalScore(List<string> rounds, string mappingFile)
    {
        int total = 0;

        var possiblePoints = PossiblePointsMapping(mappingFile);
        foreach (string round in rounds)
        {
            total += possiblePoints[round];
        }
        return total;
    }

    // Parses a file that stores the points that would be earned during a certain combination
    private static Dictionary<string, int> PossiblePointsMapping(string mappingFile)
    {
        var possiblePoints = new Dictionary<string, int>();
        var combinations = File.ReadAllLines(mappingFile).ToList();
        foreach (string combination in combinations)
        {
            var combinationToPoints = combination.Split("-").ToList();
            possiblePoints.Add(combinationToPoints[0], int.Parse(combinationToPoints[1]));
        }
        return possiblePoints;

    }
}