namespace aoc_2017_csharp.Day04;

public static class Day04
{
    private static readonly string[] Input = File.ReadAllLines("Day04/day04.txt");

    public static int Part1() => Input.Count(AllWordsAreUnique);

    public static int Part2() => Input.Count(x => AllWordsAreUnique(x) && ContainsNoAnagrams(x));

    public static bool AllWordsAreUnique(string passphrase) =>
        passphrase.Split(' ').GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() }).All(g => g.Count == 1);

    public static bool ContainsNoAnagrams(string passphrase)
    {
        var query = passphrase.Split(' ')
            .Select(w => w.GroupBy(c => c).Select(g => new { g.Key, Count = g.Count() }).OrderBy(g => g.Key).ThenBy(g => g.Count).ToList())
            .ToList();

        return query.All(q => query.Count(x => x.SequenceEqual(q)) == 1);
    }
}
