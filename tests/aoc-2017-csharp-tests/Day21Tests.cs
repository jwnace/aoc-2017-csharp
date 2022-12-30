using aoc_2017_csharp.Day21;

namespace aoc_2017_csharp_tests;

public class Day21Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 155;
        var actual = Day21.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 2_449_665;
        var actual = Day21.Part2();
        actual.Should().Be(expected);
    }
}
