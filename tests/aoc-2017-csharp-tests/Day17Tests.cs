using aoc_2017_csharp.Day17;

namespace aoc_2017_csharp_tests;

public class Day17Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 1_487;
        var actual = Day17.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 25_674_054;
        var actual = Day17.Part2();
        actual.Should().Be(expected);
    }
}
