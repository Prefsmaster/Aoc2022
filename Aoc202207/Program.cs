using Aoc202207;

var dirTree = BuildDirectoryTreeFromConsoleLog(File.ReadAllLines(@"input.txt"));

Console.WriteLine(dirTree.FilterDirectories(item => item.Size <= 100_000).Sum(c => c.Size));

// for part 2 find the smallest candidate that frees a minimum = 30.000.000 - (70.000.000 - size of root) 
// this can be simplified to: size of root - 40000000
Console.WriteLine(dirTree.FilterDirectories(item => item.Size >= dirTree.Size - 40000000L).Min(c => c.Size));

static DirItem BuildDirectoryTreeFromConsoleLog(string[] logLines)
{
    var root = new DirItem(null, "/");
    var currentDir = root;
    foreach(var logLine in logLines)
    {
        if (logLine[0]=='$') // process command
        {
            if (logLine[2] != 'c') continue; // only cd does something, rest (ls) can be skipped
            currentDir = logLine[5..] switch
            {
                "/" => root,
                ".." => currentDir?.Parent,
                _ => currentDir?.Items.Single(i => i.Name == logLine[5..])
            };
        }
        else // process dir or file
        {
            var parts = logLine.Split(' ');
            currentDir?.Items.Add(new DirItem(currentDir, parts[1], logLine[0] == 'd' ? -1: long.Parse(parts[0])));
        }
    }
    return root;
}