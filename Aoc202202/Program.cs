
var instructions = File.ReadAllLines(@"input.txt");

var score = 0;
var score2 = 0;

foreach (var game in instructions)
{
    var moves = game.Split(' ');

    var opponent = moves[0][0] - 'A';
    var me = moves[1][0] - 'X';
    var iAmBeatenBy = (me + 1) % 3; // simple!!
    
    // part 1
    score += me + 1;
    if (me == opponent) score += 3;
    else
        score += (opponent == iAmBeatenBy) ? 0 : 6;

    // part 2
    // What I should pick can be calculated with a simple formula
    // for example: A Z means pick paper to defeat rock...
    // first transform to zero based index abc -> 012 xyz->012: 0 2
    // then add these = 2. then add another 2 = 4. 
    // take remainder of division by 3 = 1
    // result: Opponents rock (A=0) must be beaten (Z) by paper (B=2)
    // this works in all cases :-)
    var iMustPick = (opponent + me + 2) % 3;
    score2 += iMustPick + 1;
    // me contains desired result 0 = lose, 1 = draw, 2 = win, multiply with 3 to get score
    score2 += me * 3;

}

Console.WriteLine($"my score 1: {score}");
Console.WriteLine($"my score 2: {score2}");