namespace aoc_2017_csharp.Day05;

public static class Day05
{
    private static readonly int[] Input = File.ReadAllLines("Day05/day05.txt").Select(int.Parse).ToArray();

    public static int Part1()
    {
        var steps = 0;
        var i = 0;
        
        while (i >= 0 && i < Input.Length)
        {
            var temp = Input[i];
            Input[i]++;
            i += temp;
            steps++;
        }

        return steps;
    }

    public static int Part2() => 2;
}
