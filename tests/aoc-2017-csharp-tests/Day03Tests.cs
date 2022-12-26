using aoc_2017_csharp.Day03;

namespace aoc_2017_csharp_tests;

public class Day03Tests
{
    [TestCase(1, 0)]
    [TestCase(12, 3)]
    [TestCase(23, 2)]
    [TestCase(1024, 31)]
    public void Solve_ReturnsCorrectResult(int input, int expected)
    {
        var actual = Day03.Solve(input, 1);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 371;
        var actual = Day03.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 369_601;
        var actual = Day03.Part2();
        actual.Should().Be(expected);
    }
}