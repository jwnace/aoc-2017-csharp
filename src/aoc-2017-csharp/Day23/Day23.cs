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

    public static long Part2()
    {
        var step = 0UL;

        var registers = new Dictionary<string, long>
        {
            { "a", 1 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 },
            { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 },
            { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 },
        };

        for (var i = 0L; i < Input.Length; i++)
        {
            if (step % 10_000_000 == 0)
            {
                Console.WriteLine($"{step}");
            }

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
                    break;
                case "jnz" when xValue != 0:
                    i += yValue - 1;
                    break;
            }

            step++;
        }

        return registers["h"];
    }

    private static long RunOptimizedProgram()
    {
        long a, b, c, d, e, f, g, h = 0;
        a = 1;

        b = 99;             // set b 99
        c = b;              // set c b
        b *= 100;           // mul b 100
        b -= -100_000;      // sub b -100000
        c = b;              // set c b
        c -= -17_000;       // sub c -17000

        while (true)
        {
            f = 1; // set f 1
            d = 2; // set d 2

            while (true)
            {
                e = 2; // set e 2

                while (true)
                {
                    g = d; // set g d
                    g *= e; // mul g e
                    g -= b; // sub g b

                    if (g == 0) // jnz g 2
                    {
                        f = 0; // set f 0
                    }

                    e -= -1; // sub e -1
                    g = e; // set g e
                    g -= b; // sub g b

                    if (g == 0) // jnz g -8
                    {
                        break;
                    }
                }

                d -= -1; // sub d -1
                g = d; // set g d
                g -= b; // sub g b

                if (g == 0) // jnz g -13
                {
                    break;
                }
            }

            if (f == 0) // jnz f 2
            {
                h -= 1; // sub h -1
            }

            g = b; // set g b
            g -= c; // sub g c

            if (g == 0) // jnz g 2
            {
                return h;
            }

            b -= -17; // sub b -17
        }

        throw new Exception("something went horribly wrong");
    }
}
