namespace aoc_2017_csharp.Day24;

public static class Day24
{
    private static readonly List<Component> Components = File.ReadAllLines("Day24/day24.txt")
        .Select(line => line.Split('/').Select(int.Parse).ToArray())
        .Select(values => new Component(values[0], values[1], false, false))
        .ToList();

    public static int Part1()
    {
        var result = 0;

        // HACK: make a copy of the original list of components since we're going to make changes to it
        var components = Components.ToList();

        // the first port you use must be of type 0
        var startingComponents = components.Where(c => c.PortA == 0 || c.PortB == 0).ToList();

        foreach (var start in startingComponents)
        {
            if (start.PortA == 0)
            {
                start.IsPortAUsed = true;
            }
            else if (start.PortB == 0)
            {
                start.IsPortBUsed = true;
            }
            else
            {
                throw new InvalidOperationException("something went horribly wrong");
            }

            result = Math.Max(result, GetStrongestBridge(start, components));
        }

        // It doesn't matter what type of port you end with; your goal is just to make the bridge as strong as possible.

        // The strength of a bridge is the sum of the port types in each component. For example, if your bridge is made
        // of components 0/3, 3/7, and 7/4, your bridge has a strength of 0+3 + 3+7 + 7+4 = 24.

        return result;
    }

    public static int Part2() => 2;

    private static int GetStrongestBridge(Component start, List<Component> components)
    {
        if (start.IsPortAUsed && start.IsPortBUsed)
        {
            throw new InvalidOperationException("both ports are already in use");
        }

        var tail = start.IsPortAUsed ? start.PortB : start.PortA;

        var potentialNextComponents = components.Where(c => !c.IsPortAUsed && !c.IsPortBUsed);

        throw new NotImplementedException();
    }

    private class Component
    {
        public Component(int portA, int portB, bool isPortAUsed, bool isPortBUsed)
        {
            PortA = portA;
            PortB = portB;
            IsPortAUsed = isPortAUsed;
            IsPortBUsed = isPortBUsed;
        }

        public int PortA { get; init; }
        public int PortB { get; init; }
        public bool IsPortAUsed { get; set; }
        public bool IsPortBUsed { get; set; }

        public void Deconstruct(out int portA, out int portB, out bool isPortAUsed, out bool isPortBUsed)
        {
            portA = PortA;
            portB = PortB;
            isPortAUsed = IsPortAUsed;
            isPortBUsed = IsPortBUsed;
        }
    }
}
