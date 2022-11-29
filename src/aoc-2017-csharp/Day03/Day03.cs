namespace aoc_2017_csharp.Day03;

public static class Day03
{
    private static readonly int Input = int.Parse(File.ReadAllText("Day03/day03.txt"));

    public static int Part1() => Solve(Input, 1);

    public static int Part2() => Solve(Input, 2);

    public static int Solve(int input, int part)
    {
        var memo = new Dictionary<(int X, int Y), int> { [(0, 0)] = 1 };
        var (x, y) = (0, 0);
        var direction = 'R';

        for (var i = 2; i <= input; i++)
        {
            (x, y) = UpdatePosition(x, y, direction);

            if (part == 1)
            {
                memo[(x, y)] = i;
            }
            else if (part == 2)
            {
                var sum = SumNeighbors(x, y, memo);

                memo[(x, y)] = sum;

                if (sum > input)
                {
                    return sum;
                }
            }

            direction = UpdateDirection(x, y, memo, direction);
        }

        return Math.Abs(memo.First(pair => pair.Value == input).Key.X) + Math.Abs(memo.First(pair => pair.Value == input).Key.Y);
    }

    private static (int, int) UpdatePosition(int x, int y, char direction)
    {
        return direction switch
        {
            'R' => (x + 1, y),
            'L' => (x - 1, y),
            'U' => (x, y + 1),
            'D' => (x, y - 1),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static char UpdateDirection(int x, int y, Dictionary<(int X, int Y), int> memo, char direction)
    {
        return direction switch
        {
            'R' when !memo.TryGetValue((x, y + 1), out _) => 'U',
            'U' when !memo.TryGetValue((x - 1, y), out _) => 'L',
            'L' when !memo.TryGetValue((x, y - 1), out _) => 'D',
            'D' when !memo.TryGetValue((x + 1, y), out _) => 'R',
            _ => direction
        };
    }

    private static int SumNeighbors(int x, int y, Dictionary<(int X, int Y), int> memo)
    {
        var neighbors = new[]
        {
            (x - 1, y - 1),
            (x    , y - 1),
            (x + 1, y - 1),
            (x - 1, y    ),
            (x + 1, y    ),
            (x - 1, y + 1),
            (x    , y + 1),
            (x + 1, y + 1),
        };

        return neighbors.Where(memo.ContainsKey).Sum(n => memo[n]);
    }
}
