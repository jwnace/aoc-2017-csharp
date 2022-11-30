namespace aoc_2017_csharp.Day07;

public static class Day07
{
    private static readonly string[] Input = File.ReadAllLines("Day07/day07.txt");

    public static string Part1() => GetRootNodeName();

    public static int Part2() => GetUnbalancedNodeExpectedWeight();

    private static string GetRootNodeName()
    {
        var nodes = Input
            .Where(s => s.Contains(" -> "))
            .Select(s => s.Split(" -> "))
            .Select(a => new { Name = a[0].Split(' ')[0], Children = a[1] })
            .ToArray();

        return nodes.Single(x => !nodes.Any(y => y.Children.Contains(x.Name))).Name;
    }

    private static int GetUnbalancedNodeExpectedWeight()
    {
        var rootNodeName = GetRootNodeName();
        var rootNodeLine = Input.Single(x => x.StartsWith(rootNodeName));
        var root = Node.FromString(rootNodeLine);

        CalculateTowerWeights(root);

        return GetUnbalancedNodeExpectedWeight(root);
    }

    private static int GetUnbalancedNodeExpectedWeight(Node node)
    {
        Node? balanced = null;
        Node? unbalanced = null;

        while (true)
        {
            var towerGroups = node.Children
                .GroupBy(c => c.TowerWeight)
                .Select(g => new { TowerWeight = g.Key, Count = g.Count(), Nodes = g })
                .ToList();

            if (towerGroups.Count != 2)
            {
                var difference = balanced!.TowerWeight - unbalanced!.TowerWeight;
                return unbalanced.Weight + difference;
            }

            balanced = towerGroups.MaxBy(x => x.Count)!.Nodes.First();
            unbalanced = towerGroups.MinBy(x => x.Count)!.Nodes.Single();
            node = unbalanced;
        }
    }

    private static int CalculateTowerWeights(Node node) =>
        node.TowerWeight = node.Weight + node.Children.Sum(CalculateTowerWeights);

    private class Node
    {
        public string Name { get; init; }
        public int Weight { get; init; }
        public List<Node> Children { get; init; }
        public int TowerWeight { get; set; }

        private Node(string name, int weight)
        {
            Name = name;
            Weight = weight;
            Children = new List<Node>();
        }

        public static Node FromString(string line)
        {
            var values = line.Split(" -> ");
            var left = values[0];
            var right = values.Length > 1 ? values[1] : "";
            var leftValues = left.Split(' ');
            var name = leftValues[0];
            var weight = int.Parse(leftValues[1][1..^1]);
            var node = new Node(name, weight);
            var childNames = !string.IsNullOrWhiteSpace(right) ? right.Split(", ") : Array.Empty<string>();

            foreach (var childName in childNames)
            {
                var childString = Input.Single(x => x.StartsWith(childName));
                node.Children.Add(FromString(childString));
            }

            return node;
        }
    }
}
