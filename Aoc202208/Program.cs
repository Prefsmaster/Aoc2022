using System.Security.Cryptography.X509Certificates;

var treefield = File.ReadAllLines(@"Test.txt").ToArray();
var fieldWidth = treefield[0].Length;
var fieldHeight = treefield.Length;
// edges are visible!
var visible = (fieldWidth + fieldHeight) * 2 - 4;
// vertical...
var fromtop = 0;
var frombot = 0;

var visiblegrid = new bool[fieldHeight*fieldWidth];
for (var y=0;y<fieldHeight;y++)
    for (var x=0;x<fieldWidth;x++)
        if (x == 0 || y == 0 || x==fieldWidth-1|| y==fieldHeight-1) visiblegrid[y*fieldWidth+x] = true;

Console.WriteLine(visiblegrid.Count(g => g));

for (var x = 1; x < fieldHeight - 1; x++)
{
    var highest = treefield[0][x];
    for (var y = 1; y < fieldHeight - 1; y++)
    {
        if (treefield[y][x] > highest)
        {
            highest = treefield[y][x];
            visiblegrid[y * fieldWidth + x] = true;
        }
    }
    highest = treefield[fieldHeight - 1][x];
    for (var y = fieldHeight - 2; y > 0; y--)
    {
        if (treefield[y][x] > highest)
        {
            highest = treefield[y][x];
            visiblegrid[y * fieldWidth + x] = true;
        }
    }
}
var fromleft = 0;
var fromrght = 0;
for (var y = 1; y < fieldWidth - 1; y++)
{
    var highest = treefield[y][0];
    for (var x = 1; x < fieldWidth - 1; x++)
    {
        if (treefield[y][x] > highest)
        {
            highest = treefield[y][x];
            visiblegrid[y * fieldWidth + x] = true;
        }
    }
    highest = treefield[y][fieldWidth-1];
    for (var x = fieldWidth - 2; x > 0; x--)
    {
        if (treefield[y][x] > highest)
        {
            highest = treefield[y][x];
            visiblegrid[y * fieldWidth + x] = true;
        }
    }
}



Console.WriteLine(visiblegrid.Count(g => g));
var bestx = 0;
var besty = 0;
var bestscore = 0L;
for (var y = 1; y < fieldHeight - 1; y++)
    for (var x = 1; x < fieldWidth - 1; x++)
    {
        var score = visibilityScore(y, x);
        if (score > bestscore)
        {
            bestx = x;
            besty = y;
            bestscore = score;
        }
    }
Console.WriteLine($"{bestscore} {bestx} {besty}");

long visibilityScore(int sy, int sx)
{
    var up = 0;
    var down = 0;
    var left = 0;
    var right = 0;

    var highest = treefield[sy][sx];

    //var y = sy - 1;
    //while (y >= 0)
    //{
    //    if (treefield[y][sx] < highest) up++;
    //    if (treefield[y][sx] >= highest)
    //    {
    //        if (up > 0) up++;
    //        break;
    //    }
    //    y--;
    //}
    up = GetPathLength(sy, sx, -1, 0);
    var y = sy + 1;
    while (y < fieldHeight)
    {
        if (treefield[y][sx] < highest) down++;
        if (treefield[y][sx] >= highest)
        {
            if (down > 0) down++;
            break;
        }
        y++;
    }


    var x = sx-1;
    while (x >= 0)
    {
        if (treefield[sy][x] < highest) left++;
        if (treefield[sy][x] >= highest)
        { 
            if (left > 0) left++;
            break;
        }
        x--;
    }

    x = sx+1;
    while (x < fieldWidth)
    {
        if (treefield[sy][x] < highest) right++;
        if (treefield[sy][x] >= highest)
        {
            if (right > 0) right++;
            break;
        }
        x++;
    }
    return up*down*left*right;
}

int GetPathLength(int y, int x, int dy, int dx)
{
    var highest = treefield[y][x];
    var length = 0;
    var blocked = false;

    do
    {
        x += dx;
        y += dy;
        if (treefield[y][x] < highest) length++;
        if (treefield[y][x] >= highest)
        {
            if (length > 0) length++;
            blocked = true;
        }
    } while (!blocked && y > 0 && y < fieldHeight - 1 && x > 0 && x <= fieldWidth - 1);
    return length;
}