namespace aoc_2017_csharp.Day13;

public static class Day13
{
    private static readonly (int Depth, int Range)[] Layers = File.ReadAllLines("Day13/day13.txt")
        .Select(line => line.Split(": ").Select(int.Parse).ToArray())
        .Select(values => (Depth: values[0], Range: values[1]))
        .ToArray();

    public static int Part1()
    {
        var result = 0;
        var maxDepth = Layers.Max(layer => layer.Depth);

        for (var time = 0; time <= maxDepth; time++)
        {
            if (!Layers.Any(l => l.Depth == time))
            {
                continue;
            }

            var layer = Layers.First(l => l.Depth == time);
            var position = GetPositionAtTime(layer.Range, time);

            if (position == 0)
            {
                result += layer.Depth * layer.Range;
            }
        }

        return result;
    }

    public static int Part2()
    {
        for (var startTime = 0; startTime < int.MaxValue; startTime++)
        {
            if (AllLayersWillNotBeAtPositionZeroWhenWePassThrough(startTime))
            {
                return startTime;
            }
        }

        throw new Exception("couldn't find a solution!");
    }

    public static int GetPositionAtTime(int range, int time)
    {
        var cycle = 2 * (range - 1);
        var temp = time % cycle;

        if (temp <= cycle / 2)
        {
            return temp;
        }

        return cycle - temp;
    }

    private static bool AllLayersWillNotBeAtPositionZeroWhenWePassThrough(int time) =>
        Layers.Select(layer => GetPositionAtTime(layer.Range, time + layer.Depth)).All(position => position != 0);
}
