using aoc_2017_csharp.Day18;

namespace aoc_2017_csharp_tests;

public class Day18Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 2_951;
        var actual = Day18.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 7_366;
        var actual = Day18.Part2();
        actual.Should().Be(expected);
    }
}
