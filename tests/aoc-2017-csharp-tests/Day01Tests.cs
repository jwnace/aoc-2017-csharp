using aoc_2017_csharp.Day01;

namespace aoc_2017_csharp_tests;

public class Day01Tests
{
    [TestCase("1122", 3)]
    [TestCase("1111", 4)]
    [TestCase("1234", 0)]
    [TestCase("91212129", 9)]
    public void SolvePart1_ReturnsCorrectResult(string input, int expected)
    {
        var actual = Day01.SolvePart1(input);
        actual.Should().Be(expected);
    }

    [TestCase("1212", 6)]
    [TestCase("1221", 0)]
    [TestCase("123425", 4)]
    [TestCase("123123", 12)]
    [TestCase("12131415", 4)]
    public void SolvePart2_ReturnsCorrectResult(string input, int expected)
    {
        var actual = Day01.SolvePart2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 1_341;
        var actual = Day01.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 1_348;
        var actual = Day01.Part2();
        actual.Should().Be(expected);
    }
}
