﻿namespace aoc_2017_csharp.Day21;

public static class Day21
{
    private static readonly string[] Input = File.ReadAllLines("Day21/day21.txt");

    public static int Part1() => Solve(5);

    public static int Part2() => Solve(18);

    private static int Solve(int iterations)
    {
        var rules = GetRules();

        var image = new[]
        {
            new[] { '.', '#', '.' },
            new[] { '.', '.', '#' },
            new[] { '#', '#', '#' },
        };

        for (var i = 0; i < iterations; i++)
        {
            if (image.Length % 2 == 0)
            {
                // divide up into 2x2 chunks
                var chunkSize = 2;
                var chunksPerRow = image.Length / chunkSize;
                var chunks = new List<char[][]>();

                for (var r = 0; r < chunksPerRow * chunkSize; r += chunkSize)
                {
                    for (var c = 0; c < chunksPerRow * chunkSize; c += chunkSize)
                    {
                        var chunk = new[]
                        {
                            new[] { image[r    ][c], image[r    ][c + 1], },
                            new[] { image[r + 1][c], image[r + 1][c + 1], },
                        };

                        chunks.Add(chunk);
                    }
                }

                var enhancedChunks = chunks.Select(chunk => EnhanceChunk(rules, chunk)).ToList();

                image = CombineChunks(enhancedChunks);
            }
            else if (image.Length % 3 == 0)
            {
                // divide up into 3x3 chunks
                var chunkSize = 3;
                var chunksPerRow = image.Length / chunkSize;
                var chunks = new List<char[][]>();

                for (var r = 0; r < chunksPerRow * chunkSize; r += chunkSize)
                {
                    for (var c = 0; c < chunksPerRow * chunkSize; c += chunkSize)
                    {
                        var chunk = new[]
                        {
                            new[] { image[r    ][c], image[r    ][c + 1], image[r    ][c + 2] },
                            new[] { image[r + 1][c], image[r + 1][c + 1], image[r + 1][c + 2] },
                            new[] { image[r + 2][c], image[r + 2][c + 1], image[r + 2][c + 2] },
                        };

                        chunks.Add(chunk);
                    }
                }

                var enhancedChunks = chunks.Select(chunk => EnhanceChunk(rules, chunk)).ToList();

                image = CombineChunks(enhancedChunks);
            }
        }

        return image.Sum(chars => chars.Count(c => c == '#'));
    }

    private static char[][] CombineChunks(List<char[][]> chunks)
    {
        if (chunks.Count == 1)
        {
            return chunks.Single();
        }

        var chunksPerRow = (int)Math.Sqrt(chunks.Count);
        var chunkSize = chunks[0].Length;
        var image = new List<List<char>>();
        var chunkedChunks = chunks.Chunk(chunksPerRow).ToArray();

        for (var i = 0; i < chunksPerRow * chunkSize; i++)
        {
            var query = chunkedChunks[i / chunkSize].Select(x => x[i % chunkSize]);
            image.Add(query.SelectMany(x => x).ToList());
        }

        return image.Select(x => x.ToArray()).ToArray();
    }

    private static char[][] EnhanceChunk(List<Rule> rules, char[][] image)
    {
        var firstMatchingRule = rules
            .FirstOrDefault(rule => rule.InputPatterns.Any(pattern => AreEquivalent(pattern, image)));

        if (firstMatchingRule is null)
        {
            throw new InvalidOperationException("couldn't find a matching rule!");
            return image;
        }

        var firstMatchingPattern = firstMatchingRule.InputPatterns
            .Select((pattern, index) => new { Pattern = pattern, Index = index })
            .FirstOrDefault(x => AreEquivalent(x.Pattern, image));

        if (firstMatchingPattern is null)
        {
            throw new InvalidOperationException("couldn't find a matching pattern!");
            return image;
        }

        // TODO: we don't actually need to match the index, we can just use index 0
        // var index = firstMatchingPattern.Index;
        var index = 0;
        var outputPattern = firstMatchingRule.OutputPatterns[index];

        // TODO: this only works when the entire image matches a pattern
        // TODO: we need to implement splitting the image up into sub-sections and matching them to patterns
        image = outputPattern;
        return image;
    }

    private static bool AreEquivalent(char[][] pattern, char[][] image) =>
        pattern.SelectMany(c => c).SequenceEqual(image.SelectMany(c => c));

    private static List<Rule> GetRules()
    {
        var rules = new List<Rule>();

        foreach (var line in Input)
        {
            var values = line.Split(" => ");
            var left = values[0];
            var right = values[1];

            var leftValues = left.Split('/').ToArray();
            var rightValues = right.Split('/').ToArray();

            var inputVariations = GetVariations(leftValues);
            var outputVariations = GetVariations(rightValues);

            rules.Add(new Rule(inputVariations, outputVariations));
        }

        return rules;
    }

    private static char[][][] GetVariations(string[] pattern)
    {
        if (pattern.Length == 2)
        {
            return new[]
            {
                new[]
                {
                    new[] { pattern[0][0], pattern[0][1] },
                    new[] { pattern[1][0], pattern[1][1] },
                },
                new[]
                {
                    new[] { pattern[1][0], pattern[0][0] },
                    new[] { pattern[1][1], pattern[0][1] },
                },
                new[]
                {
                    new[] { pattern[1][1], pattern[1][0] },
                    new[] { pattern[0][1], pattern[0][0] },
                },
                new[]
                {
                    new[] { pattern[0][1], pattern[1][1] },
                    new[] { pattern[0][0], pattern[1][0] },
                },
                new[]
                {
                    new[] { pattern[0][1], pattern[0][0] },
                    new[] { pattern[1][1], pattern[1][0] },
                },
                new[]
                {
                    new[] { pattern[1][1], pattern[0][1] },
                    new[] { pattern[1][0], pattern[0][0] },
                },
                new[]
                {
                    new[] { pattern[1][0], pattern[1][1] },
                    new[] { pattern[0][0], pattern[0][1] },
                },
                new[]
                {
                    new[] { pattern[0][0], pattern[1][0] },
                    new[] { pattern[0][1], pattern[1][1] },
                },
            };
        }

        if (pattern.Length == 3)
        {
            return new[]
            {
                new[]
                {
                    new[] { pattern[0][0], pattern[0][1], pattern[0][2] },
                    new[] { pattern[1][0], pattern[1][1], pattern[1][2] },
                    new[] { pattern[2][0], pattern[2][1], pattern[2][2] },
                },
                new[]
                {
                    new[] { pattern[2][0], pattern[1][0], pattern[0][0] },
                    new[] { pattern[2][1], pattern[1][1], pattern[0][1] },
                    new[] { pattern[2][2], pattern[1][2], pattern[0][2] },
                },
                new[]
                {
                    new[] { pattern[2][2], pattern[2][1], pattern[2][0] },
                    new[] { pattern[1][2], pattern[1][1], pattern[1][0] },
                    new[] { pattern[0][2], pattern[0][1], pattern[0][0] },
                },
                new[]
                {
                    new[] { pattern[0][2], pattern[1][2], pattern[2][2] },
                    new[] { pattern[0][1], pattern[1][1], pattern[2][1] },
                    new[] { pattern[0][0], pattern[1][0], pattern[2][0] },
                },

                new[]
                {
                    new[] { pattern[0][2], pattern[0][1], pattern[0][0] },
                    new[] { pattern[1][2], pattern[1][1], pattern[1][0] },
                    new[] { pattern[2][2], pattern[2][1], pattern[2][0] },
                },
                new[]
                {
                    new[] { pattern[2][2], pattern[1][2], pattern[0][2] },
                    new[] { pattern[2][1], pattern[1][1], pattern[0][1] },
                    new[] { pattern[2][0], pattern[1][0], pattern[0][0] },
                },
                new[]
                {
                    new[] { pattern[2][0], pattern[2][1], pattern[2][2] },
                    new[] { pattern[1][0], pattern[1][1], pattern[1][2] },
                    new[] { pattern[0][0], pattern[0][1], pattern[0][2] },
                },
                new[]
                {
                    new[] { pattern[0][0], pattern[1][0], pattern[2][0] },
                    new[] { pattern[0][1], pattern[1][1], pattern[2][1] },
                    new[] { pattern[0][2], pattern[1][2], pattern[2][2] },
                },
            };
        }

        if (pattern.Length == 4)
        {
            return new[]
            {
                new[]
                {
                    new[] { pattern[0][0], pattern[0][1], pattern[0][2], pattern[0][3] },
                    new[] { pattern[1][0], pattern[1][1], pattern[1][2], pattern[1][3] },
                    new[] { pattern[2][0], pattern[2][1], pattern[2][2], pattern[2][3] },
                    new[] { pattern[3][0], pattern[3][1], pattern[3][2], pattern[3][3] },
                },
                new[]
                {
                    new[] { pattern[3][0], pattern[2][0], pattern[1][0], pattern[0][0] },
                    new[] { pattern[3][1], pattern[2][1], pattern[1][1], pattern[0][1] },
                    new[] { pattern[3][2], pattern[2][2], pattern[1][2], pattern[0][2] },
                    new[] { pattern[3][3], pattern[2][3], pattern[1][3], pattern[0][3] },
                },
                new[]
                {
                    new[] { pattern[3][3], pattern[3][2], pattern[3][1], pattern[3][0] },
                    new[] { pattern[2][3], pattern[2][2], pattern[2][1], pattern[2][0] },
                    new[] { pattern[1][3], pattern[1][2], pattern[1][1], pattern[1][0] },
                    new[] { pattern[0][3], pattern[0][2], pattern[0][1], pattern[0][0] },
                },
                new[]
                {
                    new[] { pattern[0][3], pattern[1][3], pattern[2][3], pattern[3][3] },
                    new[] { pattern[0][2], pattern[1][2], pattern[2][2], pattern[3][2] },
                    new[] { pattern[0][1], pattern[1][1], pattern[2][1], pattern[3][1] },
                    new[] { pattern[0][0], pattern[1][0], pattern[2][0], pattern[3][0] },
                },

                new[]
                {
                    new[] { pattern[0][3], pattern[0][2], pattern[0][1], pattern[0][0] },
                    new[] { pattern[1][3], pattern[1][2], pattern[1][1], pattern[1][0] },
                    new[] { pattern[2][3], pattern[2][2], pattern[2][1], pattern[2][0] },
                    new[] { pattern[3][3], pattern[3][2], pattern[3][1], pattern[3][0] },
                },
                new[]
                {
                    new[] { pattern[3][3], pattern[2][3], pattern[1][3], pattern[0][3] },
                    new[] { pattern[3][2], pattern[2][2], pattern[1][2], pattern[0][2] },
                    new[] { pattern[3][1], pattern[2][1], pattern[1][1], pattern[0][1] },
                    new[] { pattern[3][0], pattern[2][0], pattern[1][0], pattern[0][0] },
                },
                new[]
                {
                    new[] { pattern[3][0], pattern[3][1], pattern[3][2], pattern[3][3] },
                    new[] { pattern[2][0], pattern[2][1], pattern[2][2], pattern[2][3] },
                    new[] { pattern[1][0], pattern[1][1], pattern[1][2], pattern[1][3] },
                    new[] { pattern[0][0], pattern[0][1], pattern[0][2], pattern[0][3] },
                },
                new[]
                {
                    new[] { pattern[0][0], pattern[1][0], pattern[2][0], pattern[3][0] },
                    new[] { pattern[0][1], pattern[1][1], pattern[2][1], pattern[3][1] },
                    new[] { pattern[0][2], pattern[1][2], pattern[2][2], pattern[3][2] },
                    new[] { pattern[0][3], pattern[1][3], pattern[2][3], pattern[3][3] },
                },
            };
        }

        return Array.Empty<char[][]>();
    }

    private record Rule(char[][][] InputPatterns, char[][][] OutputPatterns);
}
