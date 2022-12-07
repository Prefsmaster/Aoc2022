﻿using Aoc202207;

var dirTree = ProcessCommands(File.ReadAllLines(@"input.txt"));

Console.WriteLine(dirTree.FilterDirectories(item => item.Size <= 100_000).Sum(c => c.Size));

// for part 2 find the smallest candidate that frees a minimum = 30.000.000 - (70.000.000 - size of root) 
// this can be simplified to: size of root - 40000000
Console.WriteLine(dirTree.FilterDirectories(item => item.Size >= dirTree.Size - 40000000L).Min(c => c.Size));

static DirItem ProcessCommands(string[] commands)
{
    var root = new DirItem(null, "/");
    DirItem? currentdir = root;
    foreach(var command in commands)
    {
        if (command[0]=='$')
        {
            if (command[2]=='c') // only cd does something, rest can be skipped
            {
                var dest = command.Substring(5);
                currentdir = dest switch
                {
                    "/" => root,
                    ".." => currentdir?.Parent,
                    _ => currentdir?.Items.Single(i => i.Name == dest)
                };
            }
        }
        else
        {
            if (command[0]=='d')  // add dir to list
            {
                currentdir?.Items.Add(new DirItem(currentdir, command.Substring(4)));
            }
            else                 // add file to list
            {
                var parts = command.Split(' ');
                currentdir?.Items.Add(new DirItem(currentdir, parts[1], long.Parse(parts[0])));
            }
        }
    }
    return root;
}