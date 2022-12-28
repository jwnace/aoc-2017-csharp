using aoc_2017_csharp.Day15;

namespace aoc_2017_csharp_tests;

public class Day15Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 567;
        var actual = Day15.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 323;
        var actual = Day15.Part2();
        actual.Should().Be(expected);
    }
}
