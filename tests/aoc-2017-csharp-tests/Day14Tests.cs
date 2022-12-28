using aoc_2017_csharp.Day14;

namespace aoc_2017_csharp_tests;

public class Day14Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 8_292;
        var actual = Day14.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 1_069;
        var actual = Day14.Part2();
        actual.Should().Be(expected);
    }
}
