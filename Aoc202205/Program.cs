var file = new StreamReader(@"input.txt");

var stacks = PrepStacks(file); // returns stacks in wrong(reversed) order!
// reverse and make 2 copies
var stacks1 = new List<Stack<char>>();
var stacks2 = new List<Stack<char>>();
foreach (var s in stacks)
{
    stacks1.Add(new Stack<char>(s)); // initializing with a stack reverses order 
    stacks2.Add(new Stack<char>(s)); // because it uses pop source-push destination
}
// skip empty line
file.ReadLine();
// process instructions
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

static Stack<char>[] PrepStacks(StreamReader file)
{
    var stackList = new List<Stack<char>>();
    var data = file.ReadLine();
    var numberOfStacks = data.Length/4+1;
    for (var i=0;i< numberOfStacks; i++)
        stackList.Add(new Stack<char>());

    do
    {
        for (var i = 0; i < numberOfStacks; i++)
        {
            if (data[i * 4 + 1] != ' ')
                stackList[i].Push(data[i * 4 + 1]);
        }

        data = file.ReadLine();
    } while (data[1] != '1');
    return stackList.ToArray();
}

