using aoc_2017_csharp.Day20;

namespace aoc_2017_csharp_tests;

public class Day20Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 300;
        var actual = Day20.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 502;
        var actual = Day20.Part2();
        actual.Should().Be(expected);
    }
}
