// See https://aka.ms/new-console-template for more information

var values = File.ReadAllLines(@"input.txt").ToList();

var caloriesOfElf = 0L;
var totalCaloriesPerElf = new List<long>();

foreach (var value in values)
{
    if (string.IsNullOrEmpty(value))
    {
        totalCaloriesPerElf.Add(caloriesOfElf);
        caloriesOfElf = 0;
    }
    else
    {
        caloriesOfElf += int.Parse(value);
    }
}
Console.WriteLine($"Largest 1: {totalCaloriesPerElf.MaxBy(x => x)}");
Console.WriteLine($"Largest 3: {totalCaloriesPerElf.OrderByDescending(x => x).Take(3).Sum()}");
