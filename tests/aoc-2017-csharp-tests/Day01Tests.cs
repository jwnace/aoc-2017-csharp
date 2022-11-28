using aoc_2017_csharp.Day01;
using FluentAssertions;

namespace aoc_2017_csharp_tests;

public class Day01Tests
{
    [TestCase("1122", 3)]
    [TestCase("1111", 4)]
    [TestCase("1234", 0)]
    [TestCase("91212129", 9)]
    public void SolvePart1Test(string input, int expected)
    {
        // act
        var actual = Day01.SolvePart1(input);

        // assert
        actual.Should().Be(expected);
    }

    [TestCase("1212", 6)]
    [TestCase("1221", 0)]
    [TestCase("123425", 4)]
    [TestCase("123123", 12)]
    [TestCase("12131415", 4)]
    public void SolvePart2Test(string input, int expected)
    {
        // act
        var actual = Day01.SolvePart2(input);

        // assert
        actual.Should().Be(expected);
    }
}
