using aoc_2017_csharp.Day19;

namespace aoc_2017_csharp_tests;

public class Day19Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "HATBMQJYZ";
        var actual = Day19.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 16_332;
        var actual = Day19.Part2();
        actual.Should().Be(expected);
    }
}
