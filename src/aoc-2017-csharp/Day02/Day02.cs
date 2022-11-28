using aoc_2017_csharp.Extensions;

namespace aoc_2017_csharp.Day02;

public static class Day02
{
    private static readonly string[] Input = File.ReadAllLines("Day02/day02.txt");

    public static int Part1() => SolvePart1();

    public static int Part2() => SolvePart2();

    private static int SolvePart1() => Input
        .Select(line => line.Split("\t").Select(int.Parse).ToList())
        .Select(values => values.Max() - values.Min())
        .Sum();

    private static int SolvePart2()
    {
        var checksum = 0;
        var rows = Input.Select(line => line.Split("\t").Select(int.Parse).ToList()).ToList();

        foreach (var row in rows)
        {
            var combinations = row.GetCombinations(2).ToList();

            foreach (var c in combinations.ToList())
            {
                var combination = c.ToList();
                var a = combination[0];
                var b = combination[1];

                if (a % b == 0)
                {
                    checksum += a / b;
                }

                if (b % a == 0)
                {
                    checksum += b / a;
                }
            }
        }

        return checksum;
    }
}
