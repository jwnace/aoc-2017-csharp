using aoc_2017_csharp.Day23;

namespace aoc_2017_csharp_tests;

public class Day23Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 9_409;
        var actual = Day23.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 913;
        var actual = Day23.Part2();
        actual.Should().Be(expected);
    }
}
