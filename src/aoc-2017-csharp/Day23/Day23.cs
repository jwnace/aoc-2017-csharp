namespace aoc_2017_csharp.Day23;

public static class Day23
{
    private static readonly string[] Input = File.ReadAllLines("Day23/day23.txt");

    public static int Part1()
    {
        var result = 0;
        var registers = new Dictionary<string, int>
        {
            { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 },
        };

        for (var i = 0; i < Input.Length; i++)
        {
            var line = Input[i];
            var values = line.Split(' ');
            var instruction = values[0];
            var x = values[1];
            var y = values.Length == 3 ? values[2] : "0";
            var xValue = int.TryParse(x, out var vx) ? vx : registers[x];
            var yValue = int.TryParse(y, out var vy) ? vy : registers[y];

            switch (instruction)
            {
                case "set":
                    registers[x] = yValue;
                    break;
                case "sub":
                    registers[x] -= yValue;
                    break;
                case "mul":
                    registers[x] *= yValue;
                    result++;
                    break;
                case "jnz" when xValue != 0:
                    i += yValue - 1;
                    break;
            }
        }

        return result;
    }

    public static int Part2() => CountCompositeNumbers();

    private static int CountCompositeNumbers()
    {
        var start = 109900;
        var end = start + 17_000;
        var count = 0;

        for (var i = start; i <= end; i += 17)
        {
            count += IsPrime(i) ? 0 : 1;
        }

        return count;
    }

    private static bool IsPrime(int number)
    {
        for (var i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
