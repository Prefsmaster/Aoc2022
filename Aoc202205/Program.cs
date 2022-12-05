var file = new StreamReader(@"input.txt");

var stacks = PrepStacks(file); // returns stacks in wrong(reversed) order!
// reverse and make 2 copies. initializing a stack with a stack reverses the source!
var stacks1 = stacks.Select(s => new Stack<char>(s)).ToList();
var stacks2 = stacks.Select(s => new Stack<char>(s)).ToList();

file.ReadLine(); // skip empty line

string? instruction;
while (!string.IsNullOrEmpty(instruction = file.ReadLine())) 
{
    var components = instruction.Split(" ");
    var tempStack = new Stack<char>();

    for (var moves = 0; moves < int.Parse(components[1]); moves++)
    {
        stacks1[int.Parse(components[5])-1].Push(stacks1[int.Parse(components[3])-1].Pop()); // part1 move directly
        tempStack.Push(stacks2[int.Parse(components[3]) - 1].Pop()); // part2 use intermediate stack :-)
    }
    for (var moves = 0; moves < int.Parse(components[1]); moves++)
    {
        stacks2[int.Parse(components[5]) - 1].Push(tempStack.Pop());     // part2 move intermediate stack to destination
    }
}

stacks1.ForEach(c => Console.Write(c.Peek()));
Console.WriteLine();
stacks2.ForEach(c => Console.Write(c.Peek()));
Console.WriteLine();

static List<Stack<char>> PrepStacks(StreamReader file)
{
    var data = file.ReadLine();
    var numberOfStacks = data.Length/4+1;
    var stackList = Enumerable.Range(0, numberOfStacks).Select(i => new Stack<char>()).ToList();

    while (data[1] != '1')
    {
        for (var i = 0; i < numberOfStacks; i++)
        {
            if (data[i * 4 + 1] != ' ')
                stackList[i].Push(data[i * 4 + 1]);
        }
        data = file.ReadLine();
    } 
    return stackList;
}

