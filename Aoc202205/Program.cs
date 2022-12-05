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
// process instructions
string instruction;
while (!string.IsNullOrEmpty(instruction = file.ReadLine())) 
{
    var components = instruction.Split(" ");
    // part1
    for (var moves = 0; moves < int.Parse(components[1]); moves++)
    {
        stacks1[int.Parse(components[5])-1].Push(stacks1[int.Parse(components[3])-1].Pop());
    }
    // part2 use intermediate stack :-)
    var tempStack = new Stack<char>();
    for (var moves = 0; moves < int.Parse(components[1]); moves++)
        tempStack.Push(stacks2[int.Parse(components[3]) - 1].Pop());
    for (var moves = 0; moves < int.Parse(components[1]); moves++)
        stacks2[int.Parse(components[5]) - 1].Push(tempStack.Pop());
}

printTopOfStack(stacks1);
printTopOfStack(stacks2);

static Stack<char>[] PrepStacks(StreamReader file)
{
    var stacklist = new List<Stack<char>>();
    var data = file.ReadLine();
    var stacks = data.Length/4+1;
    for (var i=0;i<stacks;i++)
        stacklist.Add(new Stack<char>());

    do
    {
        for (var i = 0; i < stacks; i++)
        {
            if (data[1 + i * 4] != ' ')
                stacklist[i].Push(data[i * 4 + 1]);
        }

        data = file.ReadLine();
    } while (data[1] != '1');

    file.ReadLine();

    return stacklist.ToArray();
}

static void printTopOfStack(List<Stack<char>> stack)
{
    foreach (var c in stack)
    {
        Console.Write(c.Peek());
    }
    Console.WriteLine();
}