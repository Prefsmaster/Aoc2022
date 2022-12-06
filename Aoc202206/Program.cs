var streams = File.ReadAllLines(@"input.txt");

foreach (var stream in streams)
{
    Console.WriteLine($"{FindMarker(stream, 4)}");
    Console.WriteLine($"{FindMarker(stream, 14)}");
    Console.WriteLine($"{FindMarkerForNext(stream, 4)}");
    Console.WriteLine($"{FindMarkerForNext(stream, 14)}");
}

static int FindMarker(string stream, int markerLength)
{
    var markerPosition = markerLength;
    while (markerPosition <= stream.Length && stream[(markerPosition - markerLength)..markerPosition].Distinct().Count() != markerLength) markerPosition++;
    return markerPosition;
}

static int FindMarkerForNext(string stream, int markerLength)
{
    for (int m = markerLength; m <= stream.Length; m++)
    {
        bool u = true;
        for (int b = m - markerLength; b < m - 1 && u; b++)
           for (int c = b + 1; c < m && u; c++)
                u = stream[b] != stream[c];
        if (u) return m;
    }

    return -1;
}