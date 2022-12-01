// See https://aka.ms/new-console-template for more information

var values = File.ReadAllLines(@"Test.txt");

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
        caloriesOfElf += long.Parse(value);
    }
}
// In case input file does not end with an empty line,
// which was the case with my hand-crafted Test.txt
if (caloriesOfElf!=0) 
    totalCaloriesPerElf.Add(caloriesOfElf);

Console.WriteLine($"Largest 1: {totalCaloriesPerElf.Max()}");
Console.WriteLine($"Largest 3: {totalCaloriesPerElf.OrderByDescending(x => x).Take(3).Sum()}");
