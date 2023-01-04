using aoc_2017_csharp.Day25;

namespace aoc_2017_csharp_tests;

public class Day25Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 4_225;
        var actual = Day25.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = "Merry Christmas!";
        var actual = Day25.Part2();
        actual.Should().Be(expected);
    }
}
