namespace aoc_2017_csharp.Day22;

public static class Day22
{
    private static readonly string[] Input = File.ReadAllLines("Day22/day22.txt");

    public static int Part1()
    {
        var result = 0;
        var grid = BuildGrid();
        var currentPosition = (Row: Input.Length / 2, Col: Input[0].Length / 2, Facing: Facing.Up);

        for (var i = 0; i < 10_000; i++)
        {
            var (row, col, facing) = currentPosition;
            var value = grid.TryGetValue((row, col), out var v) ? v : ' ';

            facing = value == '#'
                ? (Facing)(((int)facing + 1) % 4)
                : (Facing)(((int)facing + 3) % 4);

            if (value == ' ')
            {
                grid[(row, col)] = '#';
                result++;
            }
            else
            {
                grid.Remove((row, col));
            }

            currentPosition = facing switch
            {
                Facing.Up => (row - 1, col, facing),
                Facing.Right => (row, col + 1, facing),
                Facing.Down => (row + 1, col, facing),
                Facing.Left => (row, col - 1, facing),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        return result;
    }

    public static int Part2()
    {
        var result = 0;
        var grid = BuildGrid();
        var currentPosition = (Row: Input.Length / 2, Col: Input[0].Length / 2, Facing: Facing.Up);

        for (var i = 0; i < 10_000_000; i++)
        {
            var (row, col, facing) = currentPosition;
            var value = grid.TryGetValue((row, col), out var v) ? v : ' ';

            facing = value switch
            {
                ' ' => (Facing)(((int)facing + 3) % 4),
                '#' => (Facing)(((int)facing + 1) % 4),
                'F' => (Facing)(((int)facing + 2) % 4),
                _ => facing
            };

            switch (value)
            {
                case ' ':
                    grid[(row, col)] = 'W';
                    break;
                case 'W':
                    grid[(row, col)] = '#';
                    result++;
                    break;
                case '#':
                    grid[(row, col)] = 'F';
                    break;
                case 'F':
                    grid.Remove((row, col));
                    break;
            }

            currentPosition = facing switch
            {
                Facing.Up => (row - 1, col, facing),
                Facing.Right => (row, col + 1, facing),
                Facing.Down => (row + 1, col, facing),
                Facing.Left => (row, col - 1, facing),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        return result;
    }

    private static Dictionary<(int Row, int Col), char> BuildGrid()
    {
        var grid = new Dictionary<(int Row, int Col), char>();

        for (var r = 0; r < Input.Length; r++)
        {
            for (var c = 0; c < Input[r].Length; c++)
            {
                if (Input[r][c] == '#')
                {
                    grid[(r, c)] = '#';
                }
            }
        }

        return grid;
    }

    private enum Facing
    {
        Up,
        Right,
        Down,
        Left,
    }
}
