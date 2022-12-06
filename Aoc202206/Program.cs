var streams = File.ReadAllLines(@"input.txt");

foreach (var stream in streams)
{
    Console.WriteLine($"{FindMarker(stream, 4)}");
    Console.WriteLine($"{FindMarker(stream, 14)}");
    Console.WriteLine($"{FindMarkerOldSkool(stream, 4)}");
    Console.WriteLine($"{FindMarkerOldSkool(stream, 14)}");
}

static int FindMarker(string stream, int markerLength)
{
    var markerPosition = markerLength;
    while (markerPosition <= stream.Length && stream[(markerPosition - markerLength)..markerPosition].Distinct().Count() != markerLength) markerPosition++;
    return markerPosition;
}

// slightly less readable, but works too!
static int FindMarkerOldSkool(string s, int l)
{
    for (var m = l; m <= s.Length; m++)
    {
        var u = true;
        for (var b = m - l; b < m - 1 && u; b++)
           for (var c = b + 1; c < m && u; c++)
                u = s[b] != s[c];
        if (u) return m;
    }

    return -1;
}