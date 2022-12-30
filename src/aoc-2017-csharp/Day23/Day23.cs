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

        // instructions say to start with register a = 1
        a = 1;

        // set b 99
        b = 99;

        // set c b
        c = b;

        // jnz a 2
        // a is always going to be greater than zero, so we will always skip the next instruction

        // jnz 1 5
        // this instruction will always be skipped

        // mul b 100
        b *= 100;

        // sub b -100000
        b -= -100_000;

        // set c b
        c = b;

        // sub c -17000
        c -= -17_000;

        // set f 1
        f = 1;

        // set d 2
        d = 2;

        // set e 2
        e = 2;

        // set g d
        g = d;

        // mul g e
        g *= e;

        // sub g b
        g -= b;

        // jnz g 2
        // TODO: figure this out

        // set f 0
        f = 0;

        // sub e -1
        e -= -1;

        // set g e
        g = e;

        // sub g b
        g -= b;

        // jnz g -8
        // TODO: figure this out

        // sub d -1
        d -= -1;

        // set g d
        g = d;

        // sub g b
        g -= b;

        // jnz g -13
        // TODO: figure this out

        // jnz f 2
        // TODO: figure this out

        // sub h -1
        h -= 1;

        // set g b
        g = b;

        // sub g c
        g -= c;

        // jnz g 2
        // TODO: figure this out

        // jnz 1 3
        // TODO: figure this out

        // sub b -17
        b -= -17;

        // jnz 1 -23
        // TODO: figure this out

        throw new NotImplementedException();
    }
}
