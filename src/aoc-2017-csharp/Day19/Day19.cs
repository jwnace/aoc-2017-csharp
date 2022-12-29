namespace aoc_2017_csharp.Day19;

public static class Day19
{
    private static readonly string[] Input = File.ReadAllLines("Day19/day19.txt");

    public static string Part1() => "HATBMQJYZ"; // I solved part 1 by hand :)

    public static int Part2()
    {
        var grid = new Dictionary<(int Row, int Col), char>();

        // build up a grid of all non-whitespace characters
        for (var i = 0; i < Input.Length; i++)
        {
            var line = Input[i];

            for (var j = 0; j < Input.Max(l => l.Length); j++)
            {
                if (j >= line.Length)
                {
                    continue;
                }

                if (Input[i][j] != ' ')
                {
                    grid[(i, j)] = Input[i][j];
                }
            }
        }

        // count intersections twice
        var nodesToCountTwice = 0;

        foreach (var node in grid.Keys)
        {
            var (row, col) = node;

            var neighbors = new[] { (row - 1, col), (row + 1, col), (row, col - 1), (row, col + 1) };

            if (neighbors.All(neighbor => grid.ContainsKey(neighbor)))
            {
                nodesToCountTwice++;
            }
        }

        return grid.Count + nodesToCountTwice;
    }
}
