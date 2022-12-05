var assignments = File.ReadAllLines(@"input.txt");
var result1 = 0;
var result2 = 0;
foreach (var assignment in assignments)
{
    var parts = assignment.Split(',');
    var bounds1 = parts[0].Split('-').Select(int.Parse).ToArray();
    var bounds2 = parts[1].Split('-').Select(int.Parse).ToArray();
    var range1 = Enumerable.Range(bounds1[0], bounds1[1] - bounds1[0] + 1);
    var range2 = Enumerable.Range(bounds2[0], bounds2[1] - bounds2[0] + 1);

    var intersection = range1.Intersect(range2);
    if (intersection.Any())
    {
        result2++;
        if (intersection.SequenceEqual(range1) || intersection.SequenceEqual(range2))
            result1++;
    }
}
Console.WriteLine(result1);
Console.WriteLine(result2);
