namespace aoc_2017_csharp.Shared;

public static class KnotHasher
{
    public static string GetKnotHash(string input)
    {
        var inputAsBytes = input.Select(Convert.ToByte).ToArray();
        var list = GetList(256);
        var lengths = inputAsBytes.Concat(new byte[] { 17, 31, 73, 47, 23 }).ToArray();
        var currentPosition = 0;
        var skipSize = 0;

        for (var i = 0; i < 64; i++)
        {
            KnotHash(list, lengths, ref currentPosition, ref skipSize);
        }

        var denseHash = list.Chunk(16).Select(chunk => chunk.Aggregate((a, b) => (byte)(a ^ b))).ToArray();
        return Convert.ToHexString(denseHash).ToLowerInvariant();
    }

    private static byte[] GetList(int length)
    {
        var result = new byte[length];

        for (var i = 0; i < length; i++)
        {
            result[i] = (byte)i;
        }

        return result;
    }

    private static void KnotHash(byte[] list, byte[] lengths, ref int currentPosition, ref int skipSize)
    {
        foreach (var length in lengths)
        {
            ReverseSublist(currentPosition, length, list);

            currentPosition = (currentPosition + length + skipSize) % list.Length;
            skipSize++;
        }
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
}
