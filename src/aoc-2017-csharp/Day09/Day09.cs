namespace aoc_2017_csharp.Day09;

public static class Day09
{
    private static readonly string Input = File.ReadAllText("Day09/day09.txt");

    public static int Part1() => GetScore(Input);

    public static int Part2() => CountGarbage(Input);

    public static int CountGroups(string input)
    {
        var groupCount = 0;
        var stack = new Stack<char>();

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];

            switch (c)
            {
                case '!':
                    i++;
                    break;
                case '{' or '<' when stack.Count == 0 || stack.Peek() != '<':
                    stack.Push(c);
                    break;
                case '}' when stack.Peek() == '{':
                    stack.Pop();
                    groupCount++;
                    break;
                case '>' when stack.Peek() == '<':
                    stack.Pop();
                    break;
            }
        }

        return groupCount;
    }

    public static int GetScore(string input)
    {
        var totalScore = 0;
        var stack = new Stack<char>();
        var scores = new Stack<int>();

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];

            switch (c)
            {
                case '!':
                    i++;
                    break;
                case '{' when stack.Count == 0 || stack.Peek() != '<':
                    var temp = scores.TryPeek(out var value) ? value : 0;
                    scores.Push(temp + 1);
                    stack.Push(c);
                    break;
                case '<' when stack.Count == 0 || stack.Peek() != '<':
                    stack.Push(c);
                    break;
                case '}' when stack.Peek() == '{':
                    stack.Pop();
                    totalScore += scores.Pop();
                    break;
                case '>' when stack.Peek() == '<':
                    stack.Pop();
                    break;
            }
        }

        return totalScore;
    }

    public static int CountGarbage(string input)
    {
        var garbageCount = 0;
        var stack = new Stack<char>();

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];

            switch (c)
            {
                case '!':
                    i++;
                    break;
                case '{' or '<' when stack.Count == 0 || stack.Peek() != '<':
                    stack.Push(c);
                    break;
                case '}' when stack.Peek() == '{':
                case '>' when stack.Peek() == '<':
                    stack.Pop();
                    break;
                default:
                    garbageCount += stack.Peek() == '<' ? 1 : 0;
                    break;
            }
        }

        return garbageCount;
    }
}
