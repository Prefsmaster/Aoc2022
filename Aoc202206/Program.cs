var streams = File.ReadAllLines(@"input.txt");
foreach (var stream in streams)
{
    Console.WriteLine($"{FindMarker(stream, 4)}");
    Console.WriteLine($"{FindMarker(stream, 14)}");
}

static int FindMarker(string str, int len)
{
    var end = len;
    while (end <= str.Length && str[(end - len)..end].Distinct().Count() != len) end++;
    return end;
}