namespace aoc_2017_csharp.Day14;

public static class Day14
{
    private static readonly string Input = File.ReadAllText("Day14/day14.txt");

    public static int Part1() => GetGrid().Count;

    public static int Part2()
    {
        var grid = GetGrid();
        var groups = GetGroups(grid);

        return groups.Count;
    }

    private static HashSet<(int Row, int Col)> GetGrid()
    {
        var grid = new HashSet<(int Row, int Col)>();

        for (var row = 0; row < 128; row++)
        {
            var key = $"{Input}-{row}";
            var hash = KnotHasher.GetKnotHash(key);
            var hexValues = hash.Select(GetHexValue);
            var binaryValues = hexValues.Select(hex => Convert.ToString(hex, 2).PadLeft(4, '0'));
            var usedSquareIndexes = string.Join("", binaryValues)
                .Select((character, index) => (character, index))
                .Where(x => x.character == '1')
                .Select(x => x.index)
                .ToArray();

            foreach (var col in usedSquareIndexes)
            {
                grid.Add((row, col));
            }
        }

        return grid;
    }

    private static List<List<(int Row, int Col)>> GetGroups(HashSet<(int Row, int Col)> grid)
    {
        var groups = new List<List<(int Row, int Col)>>();

        for (var row = 0; row < 128; row++)
        {
            for (var col = 0; col < 128; col++)
            {
                if (!grid.Contains((row, col)) || groups.Any(group => group.Contains((row, col))))
                {
                    continue;
                }

                var group = GetGroup(row, col, grid);
                groups.Add(group);
            }
        }

        return groups;
    }

    private static List<(int Row, int Col)> GetGroup(int row, int col, HashSet<(int Row, int Col)> grid)
    {
        var group = new List<(int Row, int Col)>();

        var queue = new Queue<(int Row, int Col)>();
        queue.Enqueue((row, col));

        var seen = new HashSet<(int Row, int Col)>();

        while (queue.Any())
        {
            var node = queue.Dequeue();

            if (seen.Contains(node))
            {
                continue;
            }

            seen.Add(node);

            var (r, c) = node;

            var neighbors = new[]
            {
                (r - 1, c),
                (r + 1, c),
                (r, c - 1),
                (r, c + 1),
            };

            foreach (var neighbor in neighbors)
            {
                if (!grid.Contains(neighbor))
                {
                    continue;
                }

                group.Add(neighbor);
                queue.Enqueue(neighbor);
            }
        }

        return group;
    }

    private static int GetHexValue(char c)
    {
        return c switch
        {
            '0' => 0,
            '1' => 1,
            '2' => 2,
            '3' => 3,
            '4' => 4,
            '5' => 5,
            '6' => 6,
            '7' => 7,
            '8' => 8,
            '9' => 9,
            'a' => 10,
            'b' => 11,
            'c' => 12,
            'd' => 13,
            'e' => 14,
            'f' => 15,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
    }
}
