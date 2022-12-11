using Aoc202211;

var puzzleInput = File.ReadAllLines(@"input.txt");
var monkeys = puzzleInput.Chunk(7).Select(c=>new Monkey(c)).ToArray();

SolveDay11(20);
SolveDay11(10000, true);

void SolveDay11(int roundstoplay, bool useModulo = false)
{
    foreach (var monkey in monkeys) monkey.ItemsInspected = 0;

    var modulo = useModulo? monkeys.Select(m => m.Divisor).Aggregate((x, y) => x * y) : 0L;
    
    while (roundstoplay-- > 0) foreach (var m in monkeys) m.PlayRound(monkeys, modulo);

    var MonkeyBusiness = monkeys.Select(m => m.ItemsInspected).OrderDescending().Take(2).Aggregate((x, y) => x * y);
    Console.WriteLine(MonkeyBusiness);
}
