using System.Security.Cryptography.X509Certificates;

var treeField = File.ReadAllLines(@"input.txt").ToArray();
var fieldSide = treeField[0].Length-1; // -1 used most, <= used where full side is needed!

// Part 1
var visibleTrees = 0L;
var highestScore = 0L;
for (var y = 0; y <= fieldSide; y++)
{
    for (var x = 0; x <= fieldSide; x++)
    {
        var visible = TreeVisibleFromEdge(y, x);
        if (visible) visibleTrees++;
        Console.Write(visible?"@":" ");
        highestScore = Math.Max(VisibleTreeScore(y, x), highestScore);
    }
    Console.WriteLine();
}

Console.WriteLine(visibleTrees);
Console.WriteLine(highestScore);

bool TreeVisibleFromEdge(int sy, int sx)
{
    return GetVisibleTrees(sy, sx, -1, 0) == sy ||
           GetVisibleTrees(sy, sx, 1, 0) == (fieldSide - sy) ||
           GetVisibleTrees(sy, sx, 0, -1) == sx ||
           GetVisibleTrees(sy, sx, 0, 1) == (fieldSide - sx);
}

long VisibleTreeScore(int sy, int sx)
{
    return GetVisibleTrees(sy, sx, -1, 0, true) * 
           GetVisibleTrees(sy, sx, 1, 0, true) * 
           GetVisibleTrees(sy, sx, 0, -1, true) * 
           GetVisibleTrees(sy, sx, 0, 1, true);
}

int GetVisibleTrees(int y, int x, int dy, int dx, bool part2 = false)
{
    var highest = treeField[y][x];
    var length = 0;
    while (y > 0 && y < fieldSide && x > 0 && x < fieldSide)
    {
        if (part2) length++; // part 2 pre-increment: always 1 tree!
        x += dx; y += dy;
        if (treeField[y][x] >= highest) break;
        if(!part2) length++; // part 1 post-increment: count only when actually lower!
    }
    return length;
}
