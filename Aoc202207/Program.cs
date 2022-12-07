using Aoc202207;

var dirTree = BuildDirectoryTreeFromConsoleLog(File.ReadAllLines(@"input.txt"));

Console.WriteLine(dirTree.FilterDirectories(item => item.Size <= 100_000).Sum(c => c.Size));

// for part 2 find the smallest candidate that frees a minimum = 30.000.000 - (70.000.000 - size of root) 
// this can be simplified to: size of root - 40000000
Console.WriteLine(dirTree.FilterDirectories(item => item.Size >= dirTree.Size - 40000000L).Min(c => c.Size));

static DirItem BuildDirectoryTreeFromConsoleLog(string[] commands)
{
    var root = new DirItem(null, "/");
    var currentDir = root;
    foreach(var command in commands)
    {
        if (command[0]=='$')
        {
            if (command[2] != 'c') continue; // only cd does something, rest can be skipped
            currentDir = command[5..] switch
            {
                "/" => root,
                ".." => currentDir?.Parent,
                _ => currentDir?.Items.Single(i => i.Name == command[5..])
            };
        }
        else // add new item (dir or file) to list
        {
            var parts = command.Split(' ');
            currentDir?.Items.Add(new DirItem(currentDir, parts[1], command[0] == 'd' ? -1: long.Parse(parts[0])));
        }
    }
    return root;
}