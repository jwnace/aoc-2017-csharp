namespace aoc_2017_csharp.Day06;

public static class Day06
{
    public static string Input = File.ReadAllText("Day06/day06.txt");

    public static int Part1() => SolvePart1();

    public static int Part2() => SolvePart2();

    private static int SolvePart1()
    {
        var cycles = 0;
        var states = new List<int[]>();
        var state = Input.Split('\t').Select(int.Parse).ToArray();
        states.Add(state.ToArray());

        while (true)
        {
            var bank = state.Select((x, i) => new { Index = i, Blocks = x }).First(x => x.Blocks == state.Max());
            state[bank.Index] = 0;

            for (var i = 1; i <= bank.Blocks; i++)
            {
                state[(bank.Index + i) % state.Length]++;
            }

            cycles++;

            if (states.Any(x => x.SequenceEqual(state)))
            {
                return cycles;
            }

            states.Add(state.ToArray());
        }
    }

    private static int SolvePart2()
    {
        var cycles = 0;
        var states = new List<int[]>();
        var state = GetRecurringState();
        states.Add(state.ToArray());

        while (true)
        {
            var bank = state.Select((x, i) => new { Index = i, Blocks = x }).First(x => x.Blocks == state.Max());
            state[bank.Index] = 0;

            for (var i = 1; i <= bank.Blocks; i++)
            {
                state[(bank.Index + i) % state.Length]++;
            }

            cycles++;

            if (states.Any(x => x.SequenceEqual(state)))
            {
                return cycles;
            }

            states.Add(state.ToArray());
        }
    }

    private static int[] GetRecurringState()
    {
        var cycles = 0;
        var states = new List<int[]>();
        var state = Input.Split('\t').Select(int.Parse).ToArray();
        states.Add(state.ToArray());

        while (true)
        {
            var bank = state.Select((x, i) => new { Index = i, Blocks = x }).First(x => x.Blocks == state.Max());
            state[bank.Index] = 0;

            for (var i = 1; i <= bank.Blocks; i++)
            {
                state[(bank.Index + i) % state.Length]++;
            }

            cycles++;

            states.Add(state.ToArray());

            if (states.Count(x => x.SequenceEqual(state)) > 1)
            {
                return state;
            }
        }
    }
}
