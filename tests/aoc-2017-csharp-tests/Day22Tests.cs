using aoc_2017_csharp.Day22;

namespace aoc_2017_csharp_tests;

public class Day22Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 5_256;
        var actual = Day22.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 2_511_345;
        var actual = Day22.Part2();
        actual.Should().Be(expected);
    }
}
