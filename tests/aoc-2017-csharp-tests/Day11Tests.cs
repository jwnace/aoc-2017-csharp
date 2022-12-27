using aoc_2017_csharp.Day11;

namespace aoc_2017_csharp_tests;

public class Day11Tests
{
    [TestCase("ne,ne,ne", -2, 3)]
    [TestCase("ne,ne,sw,sw", 0, 0)]
    [TestCase("ne,ne,s,s", 1, 2)]
    [TestCase("se,sw,se,sw,sw", 2, -1)]
    public void GetAllPositions_EndsAtCorrectDestination(string path, int row, int col)
    {
        var expected = new Day11.Position(row, col);
        var actual = Day11.GetAllPositions(path).Last();
        actual.Should().Be(expected);
    }

    [TestCase("ne,ne,ne", 3)]
    [TestCase("ne,ne,ne,ne", 4)]
    [TestCase("ne,ne,ne,ne,ne", 5)]
    [TestCase("ne,ne,ne,ne,ne,ne", 6)]
    [TestCase("ne,ne,ne,ne,ne,ne,ne", 7)]
    [TestCase("ne,ne,ne,s,s,s,s", 4)]
    [TestCase("ne,ne,ne,n,n", 5)]
    [TestCase("ne,ne,sw,sw", 0)]
    [TestCase("ne,ne,s,s", 2)]
    [TestCase("se,sw,se,sw,sw", 3)]
    [TestCase("nw,nw,nw,s,s,s,ne,ne,ne", 0)]
    public void GetDistance_ForGivenPath_ReturnsCorrectResult(string path, int expected)
    {
        var destination = Day11.GetAllPositions(path).Last();
        var actual = Day11.GetDistance(destination);
        actual.Should().Be(expected);
    }

    [TestCase(-4, -3, 5)]
    [TestCase(-3, -3, 4)]
    [TestCase(-2, -3, 3)]
    [TestCase(4, -3, 6)]
    [TestCase(3, -3, 5)]
    [TestCase(2, -3, 4)]
    [TestCase(0, 3, 3)]
    [TestCase(0, 2, 2)]
    [TestCase(0, 1, 1)]
    [TestCase(0, 0, 0)]
    [TestCase(-1, 3, 3)]
    [TestCase(1, 3, 3)]
    public void GetDistance_ForGivenCoordinate_ReturnsCorrectResult(int row, int col, int expected)
    {
        var destination = new Day11.Position(row, col);
        var actual = Day11.GetDistance(destination);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 707;
        var actual = Day11.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 1_490;
        var actual = Day11.Part2();
        actual.Should().Be(expected);
    }
}
