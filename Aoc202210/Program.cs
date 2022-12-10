var puzzleInput = File.ReadAllLines(@"input.txt");

var RegisterX = 1;
var CPUcycle = 1;
var CRTcycle = 0;

long answer = 0;

foreach (var instruction in puzzleInput)
{
    UpdateAnswer(++CPUcycle);
    UpdateCrt(CRTcycle++);
    if (instruction[0] != 'n')
    {
        UpdateCrt(CRTcycle++);
        RegisterX += int.Parse(instruction[5..]);
        UpdateAnswer(++CPUcycle);
    }
}
Console.WriteLine(answer);

void UpdateAnswer(int cycleCounter)
{
    if (cycleCounter is >= 20 and <= 220 && ((cycleCounter-20) % 40 == 0))
        answer += RegisterX * cycleCounter;
}

void UpdateCrt(int cycleCounter)
{
    var pos = cycleCounter % 40;
    Console.Write(pos>=RegisterX-1 && pos<=RegisterX+1 ? "#" : ".");
    if (pos == 39) Console.WriteLine();
}

