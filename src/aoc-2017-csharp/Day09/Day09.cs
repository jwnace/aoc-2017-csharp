namespace aoc_2017_csharp.Day09;

public static class Day09
{
    private static readonly string Input = File.ReadAllText("Day09/day09.txt");

    public static int Part1() => GetScore(Input);

    public static int Part2() => CountGarbage(Input);

    public static int CountGroups(string input)
    {
        var groups = 0;
        var stack = new Stack<char>();

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];

            if (c == '!')
            {
                i++; // increment i to skip over the next character
            }
            else if ((c == '{' || c == '<') && (stack.Count == 0 || stack.Peek() != '<'))
            {
                stack.Push(c);
            }
            else if (c == '}' && stack.Peek() == '{')
            {
                stack.Pop();
                groups++;
            }
            else if (c == '>' && stack.Peek() == '<')
            {
                stack.Pop();
            }
        }

        return groups;
    }

    public static int GetScore(string input)
    {
        var stack = new Stack<char>();
        var scores = new Stack<int>();
        var totalScore = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];

            if (c == '!')
            {
                i++; // increment i to skip over the next character
            }
            else if (c == '{' && (stack.Count == 0 || stack.Peek() != '<'))
            {
                stack.Push(c);

                var temp = scores.TryPeek(out var value) ? value : 0;
                scores.Push(temp + 1);
            }
            else if (c == '<' && (stack.Count == 0 || stack.Peek() != '<'))
            {
                stack.Push(c);
            }
            else if (c == '}' && stack.Peek() == '{')
            {
                stack.Pop();
                totalScore += scores.Pop();
            }
            else if (c == '>' && stack.Peek() == '<')
            {
                stack.Pop();
            }
        }

        return totalScore;
    }

    public static int CountGarbage(string input)
    {
        var count = 0;
        var stack = new Stack<char>();

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];

            if (c == '!')
            {
                i++; // increment i to skip over the next character
            }
            else if (c == '{' && (stack.Count == 0 || stack.Peek() != '<'))
            {
                stack.Push(c);
            }
            else if (c == '<' && (stack.Count == 0 || stack.Peek() != '<'))
            {
                stack.Push(c);
            }
            else if (c == '}' && stack.Peek() == '{')
            {
                stack.Pop();
            }
            else if (c == '>' && stack.Peek() == '<')
            {
                stack.Pop();
            }
            else if (stack.Peek() == '<')
            {
                count++;
            }
        }

        return count;
    }
}
