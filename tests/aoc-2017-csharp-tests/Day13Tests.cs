using aoc_2017_csharp.Day13;

namespace aoc_2017_csharp_tests;

public class Day13Tests
{
    [TestCase(0, 5,  0, 0)]
    [TestCase(0, 5,  1, 1)]
    [TestCase(0, 5,  2, 2)]
    [TestCase(0, 5,  3, 3)]
    [TestCase(0, 5,  4, 4)]
    [TestCase(0, 5,  5, 3)]
    [TestCase(0, 5,  6, 2)]
    [TestCase(0, 5,  7, 1)]
    [TestCase(0, 5,  8, 0)]
    [TestCase(0, 5,  9, 1)]
    [TestCase(0, 5, 10, 2)]
    [TestCase(0, 5, 11, 3)]
    [TestCase(0, 5, 12, 4)]
    [TestCase(0, 5, 13, 3)]
    [TestCase(0, 5, 14, 2)]
    [TestCase(0, 5, 15, 1)]
    [TestCase(0, 5, 16, 0)]
    [TestCase(7, 6,  0, 0)]
    [TestCase(7, 6,  1, 1)]
    [TestCase(7, 6,  2, 2)]
    [TestCase(7, 6,  3, 3)]
    [TestCase(7, 6,  4, 4)]
    [TestCase(7, 6,  5, 5)]
    [TestCase(7, 6,  6, 4)]
    [TestCase(7, 6,  7, 3)]
    [TestCase(7, 6,  8, 2)]
    [TestCase(7, 6,  9, 1)]
    [TestCase(7, 6, 10, 0)]
    [TestCase(7, 6, 11, 1)]
    [TestCase(7, 6, 12, 2)]
    [TestCase(7, 6, 13, 3)]
    [TestCase(7, 6, 14, 4)]
    [TestCase(7, 6, 15, 5)]
    [TestCase(7, 6, 16, 4)]
    [TestCase(7, 6, 17, 3)]
    [TestCase(7, 6, 18, 2)]
    [TestCase(7, 6, 19, 1)]
    [TestCase(7, 6, 20, 0)]
    public void GetPositionAtTime_ReturnsCorrectResult(int depth, int range, int time, int expected)
    {
        var actual = Day13.GetPositionAtTime(range, time);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 1_844;
        var actual = Day13.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 3_897_604;
        var actual = Day13.Part2();
        actual.Should().Be(expected);
    }
}
