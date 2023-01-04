namespace aoc_2017_csharp.Day24;

public static class Day24
{
    private static readonly List<Component> Components = File.ReadAllLines("Day24/day24.txt")
        .Select(line => line.Split('/').Select(int.Parse).ToArray())
        .Select(values => new Component(values[0], values[1]))
        .ToList();

    public static int Part1() => GetStrongestBridge(0, Components);

    public static int Part2() => GetStrongestLongestBridge(0, Components).Strength;

    private static int GetStrongestBridge(int tail, List<Component> components)
    {
        var candidates = components.Where(c => c.PortA == tail || c.PortB == tail).ToList();

        if (candidates.Count == 0)
        {
            return 0;
        }

        var best = 0;
        
        foreach (var candidate in candidates)
        {
            var newTail = candidate.PortA == tail ? candidate.PortB : candidate.PortA;
            var newList = components.Except(new[] { candidate }).ToList(); // TODO: is there a better way to do this?
            
            best = Math.Max(best, candidate.PortA + candidate.PortB + GetStrongestBridge(newTail, newList));
        }

        return best;
    }
    
    private static (int Length, int Strength) GetStrongestLongestBridge(int tail, List<Component> components)
    {
        var candidates = components.Where(c => c.PortA == tail || c.PortB == tail).ToList();

        if (candidates.Count == 0)
        {
            return (0, 0);
        }

        var bestLength = 0;
        var bestStrength = 0;
        
        foreach (var candidate in candidates)
        {
            var newTail = candidate.PortA == tail ? candidate.PortB : candidate.PortA;
            var newList = components.Except(new[] { candidate }).ToList(); // TODO: is there a better way to do this?
            
            var (tempLength, tempStrength) = GetStrongestLongestBridge(newTail, newList);

            var candidateLength = tempLength + 1;
            var candidateStrength = candidate.PortA + candidate.PortB + tempStrength;

            if (candidateLength < bestLength)
            {
                continue;
            }

            bestLength = candidateLength;
            bestStrength = Math.Max(bestStrength, candidateStrength);
        }

        return (bestLength, bestStrength);
    }
    
    private record Component(int PortA, int PortB);
}
