namespace aoc_2017_csharp.Day14;

public static class Day14
{
    private static readonly string Input = File.ReadAllText("Day14/day14.txt");

    public static int Part1()
    {
        var result = 0;

        for (var i = 0; i < 128; i++)
        {
            var temp0 = $"{Input}-{i}";
            var temp1 = Foo(temp0).ToLowerInvariant();
            var temp2 = temp1.Select(GetHexValue);
            var temp3 = temp2.Select(hex => Convert.ToString(hex, 2).PadLeft(4, '0'));
            var temp4 = string.Join("", temp3);

            result += temp4.Count(c => c == '1');
        }

        return result;
    }

    public static int Part2()
    {
        var grid = new HashSet<(int Row, int Col)>();

        for (var i = 0; i < 128; i++)
        {
            var temp0 = $"{Input}-{i}";
            var temp1 = Foo(temp0).ToLowerInvariant();
            var temp2 = temp1.Select(GetHexValue);
            var temp3 = temp2.Select(hex => Convert.ToString(hex, 2).PadLeft(4, '0'));
            var temp4 = string.Join("", temp3);
            var temp5 = temp4
                .Select((character, index) => (character, index))
                .Where(x => x.character == '1')
                .Select(x => x.index)
                .ToArray();

            foreach (var j in temp5)
            {
                var row = i;
                var col = j;

                grid.Add((row, col));
            }
        }

        var groups = new List<List<(int Row, int Col)>>();

        for (var row = 0; row < 128; row++)
        {
            for (var col = 0; col < 128; col++)
            {
                // if the square is used, and not in a group we already know about, create a new group and populate it
                if (grid.Contains((row, col)) && !groups.Any(group => group.Contains((row, col))))
                {
                    var group = GetGroup(row, col, grid);
                    groups.Add(group);
                }
            }
        }

        return groups.Count;
    }

    private static List<(int Row, int Col)> GetGroup(int row, int col, HashSet<(int Row, int Col)> grid)
    {
        if (!grid.Contains((row, col)))
        {
            throw new InvalidOperationException();
        }

        var group = new List<(int Row, int Col)>();

        // TODO: populate the group with all of the squares that belong to it
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
                if (grid.Contains(neighbor))
                {
                    group.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
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

    private static string Foo(string input)
    {
        var InputAsBytes = input.Select(Convert.ToByte).ToArray();
        var list = Day10.Day10.GetList(256);
        var lengths = InputAsBytes.Concat(new byte[] { 17, 31, 73, 47, 23 }).ToArray();
        var currentPosition = 0;
        var skipSize = 0;

        for (var i = 0; i < 64; i++)
        {
            Day10.Day10.KnotHash(list, lengths, ref currentPosition, ref skipSize);
        }

        var denseHash = list.Chunk(16).Select(chunk => chunk.Aggregate((a, b) => (byte)(a ^ b))).ToArray();
        return Convert.ToHexString(denseHash);
    }
}
