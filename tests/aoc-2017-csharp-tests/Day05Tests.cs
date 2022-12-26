using aoc_2017_csharp.Day05;

namespace aoc_2017_csharp_tests;

public class Day05Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 358_309;
        var actual = Day05.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 28_178_177;
        var actual = Day05.Part2();
        actual.Should().Be(expected);
    }
}
