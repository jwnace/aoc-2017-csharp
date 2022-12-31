using aoc_2017_csharp.Extensions;

namespace aoc_2017_csharp.Day24;

public static class Day24
{
    private static readonly string[] Input = File.ReadAllLines("Day24/day24.txt");

    public static int Part1()
    {
        // the first port you use must be of type 0

        // It doesn't matter what type of port you end with; your goal is just to make the bridge as strong as possible.

        // The strength of a bridge is the sum of the port types in each component. For example, if your bridge is made
        // of components 0/3, 3/7, and 7/4, your bridge has a strength of 0+3 + 3+7 + 7+4 = 24.

        var components = GetComponents();

        // var combinations = GetCombinations(components);

        // for (int i = 0; i < components.Count - 1; i++)
        // {
        //     for (int j = i + 1; j < components.Count; j++)
        //     {
        //
        //     }
        // }

        return 1;
    }

    private static List<(int, int)> GetComponents()
    {
        var components = new List<(int, int)>();

        foreach (var line in Input)
        {
            var values = line.Split('/').Select(int.Parse).ToArray();
            components.Add((values[0], values[1]));
        }

        return components;
    }

    public static int Part2() => 2;
}
