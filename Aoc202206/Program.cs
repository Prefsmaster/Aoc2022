var streams = File.ReadAllLines(@"input.txt");

foreach (var stream in streams)
{
    Console.WriteLine($"{FindMarker(stream, 4)}");
    Console.WriteLine($"{FindMarker(stream, 14)}");
}

static int FindMarker(string stream, int markerLength)
{
    var markerPosition = markerLength;
    while (markerPosition <= stream.Length && stream[(markerPosition - markerLength)..markerPosition].Distinct().Count() != markerLength) markerPosition++;
    return markerPosition;
}