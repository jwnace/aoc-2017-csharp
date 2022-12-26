using aoc_2017_csharp.Day06;

namespace aoc_2017_csharp_tests;

public class Day06Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 4_074;
        var actual = Day06.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 2_793;
        var actual = Day06.Part2();
        actual.Should().Be(expected);
    }
}
