namespace aoc_2017_csharp.Day16;

public static class Day16
{
    private static readonly string Input = File.ReadAllText("Day16/day16.txt");
    private static readonly char[] OriginalList =
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };

    public static string Part1()
    {
        var list = OriginalList.ToArray();

        list = Dance(list);

        return string.Join("", list);
    }

    public static string Part2()
    {
        var list = OriginalList.ToArray();
        var iterations = 1_000_000_000;

        for (var i = 0; i < iterations; i++)
        {
            if (i > 0 && list.SequenceEqual(OriginalList))
            {
                i = iterations / i * i;
            }

            list = Dance(list);
        }

        return string.Join("", list);
    }

    private static char[] Dance(char[] list)
    {
        var moves = Input.Split(',');

        foreach (var move in moves)
        {
            var temp = move[1..];

            if (move.StartsWith('s'))
            {
                var x = int.Parse(temp);
                list = Spin(list, x);
            }
            else if (move.StartsWith('x'))
            {
                var values = temp.Split('/').Select(int.Parse).ToArray();
                var (a, b) = (values[0], values[1]);
                Exchange(list, a, b);
            }
            else if (move.StartsWith('p'))
            {
                var values = temp.Split('/').Select(c => c.Single()).ToArray();
                var (a, b) = (values[0], values[1]);
                Partner(list, a, b);
            }
        }

        return list;
    }

    private static char[] Spin(char[] list, int x) => list[^x..].Concat(list[..^x]).ToArray();

    private static void Exchange(char[] list, int a, int b) => (list[a], list[b]) = (list[b], list[a]);

    private static void Partner(char[] list, char nameOfA, char nameOfB)
    {
        var a = list.ToList().IndexOf(nameOfA);
        var b = list.ToList().IndexOf(nameOfB);
        Exchange(list, a, b);
    }
}
