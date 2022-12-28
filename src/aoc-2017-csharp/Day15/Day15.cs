namespace aoc_2017_csharp.Day15;

public static class Day15
{
    private static readonly long[] Input = File.ReadAllLines("Day15/day15.txt")
        .Select(line => line.Split(' ').Last())
        .Select(long.Parse)
        .ToArray();

    public static int Part1()
    {
        var result = 0;

        var generatorA = new Generator(Input[0], 16_807L);
        var generatorB = new Generator(Input[1], 48_271L);

        for (var i = 0; i < 40_000_000L; i++)
        {
            var nextA = generatorA.GetNextValue();
            var nextB = generatorB.GetNextValue();

            var binaryA = Convert.ToString(nextA, 2).PadLeft(32, '0');
            var binaryB = Convert.ToString(nextB, 2).PadLeft(32, '0');

            var last16A = binaryA[^16..];
            var last16B = binaryB[^16..];

            if (last16A == last16B)
            {
                result++;
            }
        }

        return result;
    }

    public static int Part2()
    {
        var result = 0;

        var generatorA = new Generator(Input[0], 16_807L, 4);
        var generatorB = new Generator(Input[1], 48_271L, 8);

        for (var i = 0; i < 5_000_000L; i++)
        {
            var nextA = generatorA.GetNextValue();
            var nextB = generatorB.GetNextValue();

            var binaryA = Convert.ToString(nextA, 2).PadLeft(32, '0');
            var binaryB = Convert.ToString(nextB, 2).PadLeft(32, '0');

            var last16A = binaryA[^16..];
            var last16B = binaryB[^16..];

            if (last16A == last16B)
            {
                result++;
            }
        }

        return result;
    }

    private class Generator
    {
        private long _previousValue;
        private readonly long _factor;
        private readonly long _divisor;
        private readonly long? _criteria;

        public Generator(long seed, long factor, long? criteria = null)
        {
            _factor = factor;
            _divisor = 2_147_483_647L;
            _criteria = criteria;
            _previousValue = seed;
        }

        public long GetNextValue()
        {
            var nextValue = (_previousValue * _factor) % _divisor;
            _previousValue = nextValue;

            while (_criteria is not null && nextValue % _criteria != 0)
            {
                nextValue = (_previousValue * _factor) % _divisor;
                _previousValue = nextValue;
            }

            return nextValue;
        }
    }
}
