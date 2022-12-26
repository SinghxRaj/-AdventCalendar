using System.Numerics;

string filePath = @"D:\users\rajvi\Repos\Personal-Projects\AdventOfCode2022\DayThree\DayThree\input.txt";
Solve(filePath);


static void Solve(string filePath)
{
    Console.WriteLine(PartOne(filePath));
    Console.WriteLine(PartTwo(filePath));
}

static int PartOne(string filePath)
{
    var rucksacks = File.ReadAllLines(filePath).ToList();
    int totalPriority = 0;
    foreach(var rucksack in rucksacks)
    {
        totalPriority += CalculatePartOnePriority(rucksack);
    }

    return totalPriority;
}

static int CalculatePartOnePriority(string rucksack)
{
    var compartmentOne = rucksack.Substring(0, rucksack.Length / 2).ToCharArray().ToHashSet();
    var compartmentTwo = rucksack.Substring(rucksack.Length / 2).ToCharArray().ToHashSet();
    var priorityItem = compartmentOne.Intersect(compartmentTwo).ToList();

    if (priorityItem.Count == 1)
    {
        return PriorityValue(priorityItem[0]);
    }
    return -1;
}

static int PartTwo(string filePath)
{

    var rucksacks = File.ReadAllLines(filePath).ToList();
    int totalPriority = 0;
    for (int i = 0; i < rucksacks.Count; i += 3)
    {
        totalPriority += CalculatePartTwoPriority(rucksacks[i], rucksacks[i+1], rucksacks[i+2]);
    }

    return totalPriority;
}

static int CalculatePartTwoPriority(string elf1, string elf2, string elf3)
{
    var elf1Set = elf1.ToCharArray().ToHashSet();
    var elf2Set = elf2.ToCharArray().ToHashSet();
    var elf3Set = elf3.ToCharArray().ToHashSet();

    var badge = elf1Set.Intersect(elf2Set).ToHashSet().Intersect(elf3Set).ToList();

    if (badge.Count == 1)
    {
        return PriorityValue(badge[0]);
    }

    return -1;
}

static int PriorityValue(char item)
{
   
    if (char.IsUpper(item))
    {
        return item - 38;
    } else if (char.IsLower(item))
    {
        return item - 96;
    } else
    {
        return int.MinValue;
    }
}