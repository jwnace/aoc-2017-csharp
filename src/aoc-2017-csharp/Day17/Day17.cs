namespace aoc_2017_csharp.Day17;

public static class Day17
{
    private static readonly int Input = int.Parse(File.ReadAllText("Day17/day17.txt"));

    public static int Part1()
    {
        var list = new List<int> { 0 };
        var currentPosition = 0;

        for (var i = 1; i <= 2017; i++)
        {
            currentPosition = (currentPosition + Input) % list.Count + 1;
            list.Insert(currentPosition, i);
        }

        return list[currentPosition + 1];
    }

    public static int Part2()
    {
        var currentPosition = 0;
        var value = 0;

        for (var i = 1; i < 50_000_000; i++)
        {
            currentPosition = (currentPosition + Input) % i + 1;

            if (currentPosition == 1)
            {
                value = i;
            }
        }

        return value;
    }
}
