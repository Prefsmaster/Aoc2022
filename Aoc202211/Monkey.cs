using System.Diagnostics;

namespace Aoc202211;

public class Monkey
{
    private List<ulong> Items { get; set; }
    private char Operator { get; set; }
    private uint Argument { get; set; }
    public ulong Divisor;
    private int MoveToWhenTrue;
    private int MoveToWhenFalse;
    public ulong ItemsInspected;

    public Monkey(string[] inputData)
    {
        Items = inputData[1][18..].Split(',').Select(ulong.Parse).ToList();
        Operator = inputData[2][23];
        if (inputData[2][25] == 'o') Operator = '2';
        else Argument = uint.Parse(inputData[2][24..]);
        Divisor = uint.Parse(inputData[3][21..]);
        MoveToWhenTrue = int.Parse(inputData[4][29..]);
        MoveToWhenFalse = int.Parse(inputData[5][30..]);
    }

    public void PlayRound(Monkey[] monkeys, ulong modulo = 0)
    {
        while (Items.Any())
        {
            ItemsInspected++;
            var item = Items[0];
            Items.RemoveAt(0);
            item = Operator switch
            {
                '*' => item * Argument,
                '+' => item + Argument,
                '2' => item * item,
                _ => throw new ArgumentOutOfRangeException()
            };
            if (modulo == 0) item /= 3;
            else item %= modulo;
            monkeys[item % Divisor == 0?MoveToWhenTrue: MoveToWhenFalse].Items.Add(item);
        } 
    }
}