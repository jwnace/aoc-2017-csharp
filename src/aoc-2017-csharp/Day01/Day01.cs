namespace aoc_2017_csharp.Day01;

public static class Day01
{
    private static readonly string Input = File.ReadAllText("Day01/day01.txt");

    public static int Part1() => SolvePart1(Input);

    public static int Part2() => SolvePart2(Input);

    public static int SolvePart1(string input)
    {
        var count = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var j = (i + 1) % input.Length;

            if (input[i] == input[j])
            {
                count += int.Parse(input[i].ToString());
            }
        }

        return count;
    }

    public static int SolvePart2(string input)
    {
        var count = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var j = (i + input.Length / 2) % input.Length;

            if (input[i] == input[j])
            {
                count += int.Parse(input[i].ToString());
            }
        }

        return count;
    }
}
