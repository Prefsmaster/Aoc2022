var contents = File.ReadAllLines(@"input.txt");

Console.WriteLine (
        contents.Select (line => line[..(line.Length / 2)].Intersect(line[(line.Length / 2)..]).Single())
                .Select(common => (common > 'Z') ? common - 'a' + 1 : common - 'A' + 27)
                .Sum()
        );

Console.WriteLine (
     contents.Chunk(3)
             .Select(triplet => triplet[0].Intersect(triplet[1].Intersect(triplet[2])).Single())
             .Select(common => (common > 'Z') ? common - 'a' + 1 : common - 'A' + 27)
             .Sum()
     );

