using aoc_2017_csharp.Day24;

namespace aoc_2017_csharp_tests;

public class Day24Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 1_859;
        var actual = Day24.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 1_799;
        var actual = Day24.Part2();
        actual.Should().Be(expected);
    }
}
