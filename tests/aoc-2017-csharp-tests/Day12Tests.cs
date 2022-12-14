using aoc_2017_csharp.Day12;

namespace aoc_2017_csharp_tests;

public class Day12Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 113;
        var actual = Day12.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 202;
        var actual = Day12.Part2();
        actual.Should().Be(expected);
    }
}
