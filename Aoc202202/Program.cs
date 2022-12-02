
var instructions = File.ReadAllLines(@"input.txt");

var score1 = 0;
var score1b = 0;
var score2 = 0;

foreach (var game in instructions)
{
    var opponent = game[0] - 'A';
    var me = game[2] - 'X';

    // part 1
    var iAmBeatenBy = (me + 1) % 3; // simple!!
    score1 += me + 1;
    if (me == opponent) score1 += 3;
    else
        if (opponent != iAmBeatenBy) score1 += 6;

    // part 1b
    // can also be done with a calculation!
    // score for C Y (should be 0: Paper (me Y) loses from scissors (opponent C)
    // again make zero-based then the formula: myscore = 2 *opponent + me + 1 %3 * 3 works:
    // 2*2+1+1 = 6, 6%3 = 0, 0*3 = 0!
    // don't forget to add score for the chosen object as well:
    score1b += me + 1 + (2*opponent + me + 1)%3 * 3;

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

Console.WriteLine($"my score 1 : {score1}");
Console.WriteLine($"my score 1b: {score1b}");
Console.WriteLine($"my score 2 : {score2}");