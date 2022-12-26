using aoc_2017_csharp.Day07;

namespace aoc_2017_csharp_tests;

public class Day07Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "vgzejbd";
        var actual = Day07.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 1_226;
        var actual = Day07.Part2();
        actual.Should().Be(expected);
    }
}
