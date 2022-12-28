using aoc_2017_csharp.Day10;

namespace aoc_2017_csharp_tests;

public class Day10Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 2_928;
        var actual = Day10.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = "0c2f794b2eb555f7830766bf8fb65a16";
        var actual = Day10.Part2();
        actual.Should().Be(expected);
    }
}
