var treeField = File.ReadAllLines(@"input.txt").ToArray();
var fieldSide = treeField[0].Length;

// Part 1
var visibleGrid = new bool[fieldSide*fieldSide];
for (var vec = 1; vec < fieldSide - 1; vec++)
{
    SetVisibility(0, vec, 1, 0);
    SetVisibility(fieldSide - 1, vec, -1, 0);
    SetVisibility(vec, 0, 0, 1);
    SetVisibility(vec, fieldSide - 1, 0, -1);
}
Console.WriteLine(visibleGrid.Count(g => g)+fieldSide*4-4);

// Part 2
var highestScore = 0L;
for (var y = 1; y < fieldSide - 1; y++)
    for (var x = 1; x < fieldSide - 1; x++)
    {
        var score = VisibleTreeScore(y, x);
        if (score > highestScore)
            highestScore = score;
    }
Console.WriteLine(highestScore);

void SetVisibility(int y, int x, int dy, int dx)
{
    var highest = treeField[y][x];
    do
    {
        x += dx;
        y += dy;
        if (treeField[y][x] <= highest) continue;
        highest = treeField[y][x];
        visibleGrid[y * fieldSide + x] = true;
    } while (y > 0 && y < fieldSide - 1 && x > 0 && x < fieldSide - 1);
}


long VisibleTreeScore(int sy, int sx)
{
    return GetVisibleTrees(sy, sx, -1, 0) * 
           GetVisibleTrees(sy, sx, 1, 0) * 
           GetVisibleTrees(sy, sx, 0, -1) * 
           GetVisibleTrees(sy, sx, 0, 1);
}

int GetVisibleTrees(int y, int x, int dy, int dx)
{
    var highest = treeField[y][x];
    var length = 0;
    do
    {
        x += dx;
        y += dy;
        if (treeField[y][x] < highest)
        {
            length++;
            continue;
        }
        if (length > 0) length++;
        break;
    } while (y > 0 && y < fieldSide - 1 && x > 0 && x < fieldSide - 1);
    return length;
}