namespace aoc_2017_csharp.Day23;

public static class Day23
{
    private static readonly string[] Input = File.ReadAllLines("Day23/day23.txt");

    public static long Part1()
    {
        var result = 0;
        var registers = new Dictionary<string, long>
        {
            { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 },
            { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 },
            { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 },
        };

        for (var i = 0L; i < Input.Length; i++)
        {
            var line = Input[i];
            var values = line.Split(' ');
            var instruction = values[0];
            var x = values[1];
            var y = values.Length == 3 ? values[2] : "0";
            var xValue = long.TryParse(x, out var vx) ? vx : registers[x];
            var yValue = long.TryParse(y, out var vy) ? vy : registers[y];

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

    public static long Part2() => RunOptimizedProgram();

    private static long RunOptimizedProgram()
    {
        ulong step = 0;
        long b, c, d, e, f, h = 0;

        b = 99 * 100 + 100_000;
        c = b + 17_000;

        while (true)
        {
            f = 1;
            d = 2;

            do
            {
                if (step % 1_000 == 0)
                {
                    Console.WriteLine(step);
                }

                e = 2;

                do
                {
                    if (d * e == b)
                    {
                        f = 0;
                    }

                    e++;
                } while (e != b);

                d++;

                step++;
            } while (d != b);

            if (f == 0)
            {
                h++;
            }

            if (b == c)
            {
                return h;
            }

            b += 17;
        }
    }
}
