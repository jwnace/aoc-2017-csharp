namespace aoc_2017_csharp.Day12;

public static class Day12
{
    private static readonly string[] Input = File.ReadAllLines("Day12/day12.txt");

    public static int Part1()
    {
        var programs = GetPrograms();
        var start = programs.First(program => program.Id == 0);
        var group = GetAllProgramsInGroup(start);
        return group.Count;
    }

    public static int Part2()
    {
        var programs = GetPrograms();
        var groups = GetGroups(programs);
        return groups.Count;
    }

    private static List<Program> GetPrograms()
    {
        var programs = Input
            .Select(line => new Program(int.Parse(line.Split(" <-> ")[0]), new List<Program>()))
            .ToList();

        AssignNeighbors(programs);

        return programs;
    }

    private static void AssignNeighbors(List<Program> programs)
    {
        foreach (var line in Input)
        {
            var values = line.Split(" <-> ");
            var (left, right) = (values[0], values[1]);
            var neighbors = right.Split(", ").Select(int.Parse);
            var program = programs.First(program => program.Id == int.Parse(left));

            foreach (var neighbor in neighbors)
            {
                program.Neighbors.Add(programs.First(p => p.Id == neighbor));
            }
        }
    }

    private static List<Program> GetAllProgramsInGroup(Program start)
    {
        var result = new List<Program> { start };

        while (result.SelectMany(x => x.Neighbors).Any(y => !result.Contains(y)))
        {
            var query = result.SelectMany(x => x.Neighbors).Where(y => !result.Contains(y)).ToList();
            result.AddRange(query);
        }

        return result;
    }

    private static List<List<Program>> GetGroups(List<Program> programs)
    {
        var groups = new List<List<Program>>();

        foreach (var program in programs)
        {
            if (groups.Any(g => g.Contains(program)))
            {
                continue;
            }

            var group = GetAllProgramsInGroup(program);
            groups.Add(group);
        }

        return groups;
    }

    private record Program(int Id, List<Program> Neighbors);
}
