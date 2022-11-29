using aoc_2017_csharp.Day04;

namespace aoc_2017_csharp_tests;

public class Day04Tests
{
    [TestCase("aa bb cc dd ee", true)]
    [TestCase("aa bb cc dd aa", false)]
    [TestCase("aa bb cc dd aaa", true)]
    public void AllWordsAreUniqueTest(string input, bool expected)
    {
        // act
        var actual = Day04.AllWordsAreUnique(input);

        // assert
        actual.Should().Be(expected);
    }

    [TestCase("abcde fghij", true)]
    [TestCase("abcde xyz ecdab", false)]
    [TestCase("a ab abc abd abf abj", true)]
    [TestCase("iiii oiii ooii oooi oooo", true)]
    [TestCase("oiii ioii iioi iiio", false)]
    public void ContainsNoAnagramsTest(string input, bool expected)
    {
        // act
        var actual = Day04.ContainsNoAnagrams(input);

        // assert
        actual.Should().Be(expected);
    }
}
