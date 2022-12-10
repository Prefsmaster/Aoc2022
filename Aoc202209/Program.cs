using System.Numerics;

var puzzleInput = File.ReadAllLines(@"input.txt");

var move = new Dictionary<char, Vector2> {
    { 'U', new Vector2(0, -1) },
    { 'D', new Vector2(0, 1) },
    { 'L', new Vector2(-1, 0) },
    { 'R', new Vector2(1, 0) }
};
Vector2[] knots;

Console.WriteLine(SolveDay9(2, puzzleInput));
Console.WriteLine(SolveDay9(10, puzzleInput));

List<Vector2> visited;

int SolveDay9(int numberOfKnots, string[] instructions)
{
    knots = new Vector2[numberOfKnots];
    visited = new List<Vector2> { knots[0] };

    foreach (var instruction in instructions)
    {
        var direction = instruction[0];
        var steps = int.Parse(instruction[2..]);
        while (steps-- > 0)
        {
            knots[numberOfKnots-1] += move[direction];

            var knotToMove = numberOfKnots - 2;
            var tailMoved = false;
            while(knotToMove >= 0)
                tailMoved = MoveKnotTowardTarget(knotToMove--);

            if (tailMoved && !visited.Contains(knots[0]))
                visited.Add(knots[0]);
        }
    }
    return visited.Count;
}

bool MoveKnotTowardTarget(int knot)
{
    var delta = knots[knot+1] - knots[knot];

    if (Math.Abs(delta.X) < 2 && Math.Abs(delta.Y) < 2) return false;

    if (Math.Abs(delta.X) > 1) delta.X /= 2;
    if (Math.Abs(delta.Y) > 1) delta.Y /= 2;
    knots[knot] += delta;
    return true;
}
