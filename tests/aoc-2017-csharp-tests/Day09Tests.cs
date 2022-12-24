﻿using aoc_2017_csharp.Day09;

namespace aoc_2017_csharp_tests;

public class Day09Tests
{
    [TestCase("{}", 1)]
    [TestCase("{{{}}}", 3)]
    [TestCase("{{},{}}", 3)]
    [TestCase("{{{},{},{{}}}}", 6)]
    [TestCase("{<{},{},{{}}>}", 1)]
    [TestCase("{<a>,<a>,<a>,<a>}", 1)]
    [TestCase("{{<a>},{<a>},{<a>},{<a>}}", 5)]
    [TestCase("{{<!>},{<!>},{<!>},{<a>}}", 2)]
    public void CountGroups_ReturnsCorrectCount(string input, int expected)
    {
        // act
        var actual = Day09.CountGroups(input);

        // assert
        actual.Should().Be(expected);
    }

    [TestCase("{}", 1)]
    [TestCase("{{{}}}", 6)]
    [TestCase("{{},{}}", 5)]
    [TestCase("{{{},{},{{}}}}", 16)]
    [TestCase("{<a>,<a>,<a>,<a>}", 1)]
    [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9)]
    [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
    [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
    public void GetScore_ReturnsCorrectScore(string input, int expected)
    {
        // act
        var actual = Day09.GetScore(input);

        // assert
        actual.Should().Be(expected);
    }

    [TestCase("<>", 0)]
    [TestCase("<random characters>", 17)]
    [TestCase("<<<<>", 3)]
    [TestCase("<{!>}>", 2)]
    [TestCase("<!!>", 0)]
    [TestCase("<!!!>>", 0)]
    [TestCase("""<{o"i!a,<{i<a>""", 10)]
    public void CountGarbage_ReturnsCorrectCount(string input, int expected)
    {
        // act
        var actual = Day09.CountGarbage(input);

        // assert
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        // arrange
        var expected = 20530;

        // act
        var actual = Day09.Part1();

        // assert
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        // arrange
        var expected = 9978;

        // act
        var actual = Day09.Part2();

        // assert
        actual.Should().Be(expected);
    }
}
