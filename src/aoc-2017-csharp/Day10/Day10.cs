namespace aoc_2017_csharp.Day10;

public static class Day10
{
    private static readonly string InputAsString = File.ReadAllText("Day10/day10.txt");
    private static readonly byte[] InputAsNumbers =
        File.ReadAllText("Day10/day10.txt").Split(',').Select(byte.Parse).ToArray();

    public static int Part1()
    {
        var list = GetList(256);

        KnotHash(list, InputAsNumbers);

        var values = list.Take(2).ToArray();
        return values[0] * values[1];
    }

    public static string Part2() => KnotHasher.GetKnotHash(InputAsString);

    private static byte[] GetList(int length)
    {
        var result = new byte[length];

        for (var i = 0; i < length; i++)
        {
            result[i] = (byte)i;
        }

        return result;
    }

    private static void KnotHash(byte[] list, byte[] lengths)
    {
        var currentPosition = 0;
        var skipSize = 0;

        foreach (var length in lengths)
        {
            ReverseSublist(currentPosition, length, list);

            currentPosition = (currentPosition + length + skipSize) % list.Length;
            skipSize++;
        }
    }

    private static byte[] GetElementsToReverse(int currentPosition, int length, byte[] list)
    {
        var result = new byte[length];

        for (var i = 0; i < length; i++)
        {
            var index = (currentPosition + i) % list.Length;
            result[i] = list[index];
        }

        return result;
    }

    private static void ReverseSublist(int currentPosition, int length, byte[] list)
    {
        var reversedElements = GetElementsToReverse(currentPosition, length, list).Reverse().ToArray();

        for (var i = 0; i < length; i++)
        {
            var index = (currentPosition + i) % list.Length;
            list[index] = reversedElements[i];
        }
    }
}
