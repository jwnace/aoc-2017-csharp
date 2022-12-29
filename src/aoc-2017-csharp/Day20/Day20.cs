namespace aoc_2017_csharp.Day20;

public static class Day20
{
    private static readonly string[] Input = File.ReadAllLines("Day20/day20.txt");

    public static int Part1()
    {
        var particles = GetParticles();

        var particleWithSlowestAcceleration = particles
            .Select((particle, index) => (Particle: particle, Index: index))
            .MinBy(element =>
                Math.Abs(element.Particle.Acceleration.X) +
                Math.Abs(element.Particle.Acceleration.Y) +
                Math.Abs(element.Particle.Acceleration.Z));

        return particleWithSlowestAcceleration.Index;
    }

    public static int Part2()
    {
        var particles = GetParticles();

        // HACK: I arbitrarily chose to simulate 50 ticks... after this the particles will spread out forever
        for (var i = 0; i < 50; i++)
        {
            foreach (var particle in particles)
            {
                UpdateParticle(particle);
            }

            var collisionLocations = particles
                .GroupBy(particle => new { particle.Position.X, particle.Position.Y, particle.Position.Z })
                .Select(group => new { Position = group.Key, Count = group.Count() })
                .Where(group => group.Count > 1)
                .ToList();

            var particlesToRemove = particles
                .Where(particle =>
                    collisionLocations.Any(collision =>
                        collision.Position.X == particle.Position.X &&
                        collision.Position.Y == particle.Position.Y &&
                        collision.Position.Z == particle.Position.Z))
                .ToList();

            particles.RemoveAll(particle => particlesToRemove.Contains(particle));
        }

        return particles.Count;
    }

    private static void UpdateParticle(Particle particle)
    {
        particle.Velocity.X += particle.Acceleration.X;
        particle.Velocity.Y += particle.Acceleration.Y;
        particle.Velocity.Z += particle.Acceleration.Z;
        particle.Position.X += particle.Velocity.X;
        particle.Position.Y += particle.Velocity.Y;
        particle.Position.Z += particle.Velocity.Z;
    }

    private static List<Particle> GetParticles()
    {
        var particles = new List<Particle>();

        foreach (var line in Input)
        {
            var values = line.Split(", ");

            var p = values[0][3..^1];
            var v = values[1][3..^1];
            var a = values[2][3..^1];

            var pValues = p.Split(',').Select(int.Parse).ToArray();
            var vValues = v.Split(',').Select(int.Parse).ToArray();
            var aValues = a.Split(',').Select(int.Parse).ToArray();

            var position = new Vector(pValues[0], pValues[1], pValues[2]);
            var velocity = new Vector(vValues[0], vValues[1], vValues[2]);
            var acceleration = new Vector(aValues[0], aValues[1], aValues[2]);

            var particle = new Particle(position, velocity, acceleration);
            particles.Add(particle);
        }

        return particles;
    }

    private record Particle(Vector Position, Vector Velocity, Vector Acceleration);

    private class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
