using aoc_2017_csharp.Day16;

namespace aoc_2017_csharp_tests;

public class Day16Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = "kbednhopmfcjilag";
        var actual = Day16.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = "fbmcgdnjakpioelh";
        var actual = Day16.Part2();
        actual.Should().Be(expected);
    }
}
