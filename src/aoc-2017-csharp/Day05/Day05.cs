namespace aoc_2017_csharp.Day05;

public static class Day05
{
    private static readonly IEnumerable<int> Input = File.ReadAllLines("Day05/day05.txt").Select(int.Parse);

    public static int Part1()
    {
        var offsets = Input.ToArray();   
        var steps = 0;
        var i = 0;
        
        while (i >= 0 && i < offsets.Length)
        {
            var offset = offsets[i];
            offsets[i]++;
            i += offset;
            steps++;
        }

        return steps;
    }

    public static int Part2()
    {
        var offsets = Input.ToArray();
        var steps = 0;
        var i = 0;
        
        while (i >= 0 && i < offsets.Length)
        {
            var offset = offsets[i];
            offsets[i] += offset >= 3 ? -1 : 1;
            i += offset;
            steps++;
        }

        return steps;
    }
}
