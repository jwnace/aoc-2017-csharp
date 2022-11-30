namespace aoc_2017_csharp.Day08;

public static class Day08
{
    private static readonly string[] Input = File.ReadAllLines("Day08/day08.txt");

    public static int Part1() => Solve(1);

    public static int Part2() => Solve(2);

    private static int Solve(int part)
    {
        var registers = new Dictionary<string, int>();
        var maxValue = 0;

        foreach (var line in Input.Select(x => x.Split(' ')))
        {
            var leftValue = registers.TryGetValue(line[4], out var temp) ? temp : 0;
            var value = RunOperation(registers, line[0], line[1], int.Parse(line[2]), leftValue, line[5], int.Parse(line[6]));

            maxValue = value > maxValue ? value : maxValue;
        }

        return part == 1 ? registers.Max(x => x.Value) : maxValue;
    }

    private static int RunOperation(IDictionary<string, int> registers, string register, string operation, int amount,
        int leftValue, string conditionOperator, int rightValue)
    {
        if (!IsConditionMet(leftValue, conditionOperator, rightValue))
        {
            return 0;
        }

        var currentValue = registers.TryGetValue(register, out var value) ? value : 0;
            
        return registers[register] = operation switch
        {
            "inc" => currentValue + amount,
            "dec" => currentValue - amount,
            _ => throw new InvalidOperationException()
        };
    }

    private static bool IsConditionMet(int registerValue, string conditionOperator, int conditionValue) =>
        conditionOperator switch
        {
            "<" when registerValue < conditionValue => true,
            "<=" when registerValue <= conditionValue => true,
            ">" when registerValue > conditionValue => true,
            ">=" when registerValue >= conditionValue => true,
            "==" when registerValue == conditionValue => true,
            "!=" when registerValue != conditionValue => true,
            _ => false
        };
}
