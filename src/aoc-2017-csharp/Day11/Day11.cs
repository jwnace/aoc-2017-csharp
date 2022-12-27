namespace aoc_2017_csharp.Day11;

public static class Day11
{
    private static readonly string Path = File.ReadAllText("Day11/day11.txt");

    public static int Part1()
    {
        var destination = GetAllPositions(Path).Last();
        return GetDistance(destination);
    }

    public static int Part2()
    {
        var positions = GetAllPositions(Path);
        return positions.Max(GetDistance);
    }

    public static IEnumerable<Position> GetAllPositions(string path)
    {
        var moves = path.Split(',');
        var currentPosition = new Position(0, 0);

        foreach (var move in moves)
        {
            var (row, col) = currentPosition;

            currentPosition = move switch
            {
                "n" => new Position(row - 1, col),
                "ne" when col % 2 == 0 => new Position(row - 1, col + 1),
                "ne" when col % 2 != 0 => new Position(row, col + 1),
                "se" when col % 2 == 0 => new Position(row, col + 1),
                "se" when col % 2 != 0 => new Position(row + 1, col + 1),
                "s" => new Position(row + 1, col),
                "sw" when col % 2 == 0 => new Position(row, col - 1),
                "sw" when col % 2 != 0 => new Position(row + 1, col - 1),
                "nw" when col % 2 == 0 => new Position(row - 1, col - 1),
                "nw" when col % 2 != 0 => new Position(row, col - 1),
                _ => throw new ArgumentOutOfRangeException()
            };

            yield return currentPosition;
        }
    }

    public static int GetDistance(Position destination)
    {
        var dC = Math.Abs(destination.Col);
        var dR = Math.Abs(destination.Row);

        if (destination.Row < 0 && dR >= (dC + 1) / 2)
        {
            dR -= (dC + 1) / 2;
        }
        else if (dR >= dC / 2)
        {
            dR -= dC / 2;
        }

        return dC + dR;
    }

    public record Position(int Row, int Col);
}
