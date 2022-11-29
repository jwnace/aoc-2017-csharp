namespace aoc_2017_csharp.Day05;

public static class Day05
{
    private static readonly string[] Input = File.ReadAllLines("Day05/day05.txt");

    public static int Part1() => Solve(1);

    public static int Part2() => Solve(2);

    private static int Solve(int part)
    {
        var offsets = Input.Select(int.Parse).ToArray();
        var steps = 0;
        var i = 0;

        while (i >= 0 && i < offsets.Length)
        {
            var offset = offsets[i];
            offsets[i] += part == 2 && offset >= 3 ? -1 : 1;
            i += offset;
            steps++;
        }

        return steps;
    }
}
