var assignments = File.ReadAllLines(@"input.txt");
var result1 = 0;
var result2 = 0;
foreach (var assignment in assignments)
{
    var parts = assignment.Split(',');
    var ranges = new IEnumerable<int>[2];
    for (var i = 0; i < 2; i++)
    {
        var bounds = parts[i].Split('-').Select(int.Parse).ToArray();
        ranges[i] = Enumerable.Range(bounds[0], bounds[1] - bounds[0] + 1);
    }

    var intersection = ranges[0].Intersect(ranges[1]);
    if (intersection.Any())
    {
        result2++;
        if (intersection.SequenceEqual(ranges[0]) || intersection.SequenceEqual(ranges[1]))
            result1++;
    }
}
Console.WriteLine(result1);
Console.WriteLine(result2);
