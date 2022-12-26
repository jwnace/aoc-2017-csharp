using aoc_2017_csharp.Day04;

namespace aoc_2017_csharp_tests;

public class Day04Tests
{
    [TestCase("aa bb cc dd ee", true)]
    [TestCase("aa bb cc dd aa", false)]
    [TestCase("aa bb cc dd aaa", true)]
    public void AllWordsAreUnique_ReturnsCorrectResult(string input, bool expected)
    {
        var actual = Day04.AllWordsAreUnique(input);
        actual.Should().Be(expected);
    }

    [TestCase("abcde fghij", true)]
    [TestCase("abcde xyz ecdab", false)]
    [TestCase("a ab abc abd abf abj", true)]
    [TestCase("iiii oiii ooii oooi oooo", true)]
    [TestCase("oiii ioii iioi iiio", false)]
    public void ContainsNoAnagrams_ReturnsCorrectResult(string input, bool expected)
    {
        var actual = Day04.ContainsNoAnagrams(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 337;
        var actual = Day04.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 231;
        var actual = Day04.Part2();
        actual.Should().Be(expected);
    }
}
