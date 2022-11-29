namespace aoc_2017_csharp.Day03;

public static class Day03
{
    private static readonly int Input = int.Parse(File.ReadAllText("Day03/day03.txt"));

    public static int Part1() => SolvePart1(Input);

    public static int Part2() => 2;

    public static int SolvePart1(int input)
    {
        var memo = new Dictionary<(int X, int Y), int>();
        var (x, y) = (0, 0);
        memo[(x, y)] = 1;
        var direction = 'R';

        for (var i = 2; i <= input; i++)
        {
            // if (i % 1000 == 0 || i == input)
            // {
                // Console.WriteLine($"{i} out of {input}: {Math.Round(i / (double)input * 100.0, 2)}%");
            // }
            
            (x, y) = direction switch
            {
                'R' => (x + 1, y),
                'L' => (x - 1, y),
                'U' => (x, y + 1),
                'D' => (x, y - 1),
                _ => throw new ArgumentOutOfRangeException()
            };

            memo[(x, y)] = i;

            direction = direction switch
            {
                'R' when !memo.TryGetValue((x, y + 1), out _) => 'U',
                'U' when !memo.TryGetValue((x - 1, y), out _) => 'L',
                'L' when !memo.TryGetValue((x, y - 1), out _) => 'D',
                'D' when !memo.TryGetValue((x + 1, y), out _) => 'R',
                _ => direction
            };
        }

        return Math.Abs(memo.First(x => x.Value == input).Key.X) + Math.Abs(memo.First(x => x.Value == input).Key.Y);
    }
}
