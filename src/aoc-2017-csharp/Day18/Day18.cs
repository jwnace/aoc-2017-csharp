namespace aoc_2017_csharp.Day18;

public static class Day18
{
    private static readonly string[] Input = File.ReadAllLines("Day18/day18.txt");

    public static long Part1()
    {
        var lastSound = 0L;
        var registers = new Dictionary<string, long>
        {
            { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 },
            { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 },
            { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 },
        };

        for (var i = 0L; i < Input.Length; i++)
        {
            var line = Input[i];
            var values = line.Split(' ');
            var instruction = values[0];
            var x = values[1];
            var y = values.Length == 3 ? values[2] : "0";
            var xValue = long.TryParse(x, out var vx) ? vx : registers[x];
            var yValue = long.TryParse(y, out var vy) ? vy : registers[y];

            switch (instruction)
            {
                case "snd":
                    lastSound = xValue;
                    break;
                case "set":
                    registers[x] = yValue;
                    break;
                case "add":
                    registers[x] += yValue;
                    break;
                case "mul":
                    registers[x] *= yValue;
                    break;
                case "mod":
                    registers[x] %= yValue;
                    break;
                case "rcv" when xValue != 0L:
                    return lastSound;
                case "jgz" when xValue > 0L:
                    i += yValue - 1;
                    break;
            }
        }

        throw new Exception("couldn't find a solution!");
    }

    public static int Part2()
    {
        var programA = new Program(0);
        var programB = new Program(1);

        while (true)
        {
            programA.Run(programB);
            programB.Run(programA);

            if (programA.IsWaitingToReceiveInput && programB.IsWaitingToReceiveInput)
            {
                break;
            }
        }

        return programB.ValuesSent;
    }

    private class Program
    {
        private long _currentInstruction;
        private readonly Dictionary<string, long> _registers = new()
        {
            { "a", 0 }, { "b", 0 }, { "c", 0 }, { "d", 0 }, { "e", 0 }, { "f", 0 }, { "g", 0 }, { "h", 0 }, { "i", 0 },
            { "j", 0 }, { "k", 0 }, { "l", 0 }, { "m", 0 }, { "n", 0 }, { "o", 0 }, { "p", 0 }, { "q", 0 }, { "r", 0 },
            { "s", 0 }, { "t", 0 }, { "u", 0 }, { "v", 0 }, { "w", 0 }, { "x", 0 }, { "y", 0 }, { "z", 0 },
        };

        public Queue<long> MessageQueue { get; } = new();
        public bool IsWaitingToReceiveInput { get; private set; }
        public int ValuesSent { get; private set; }

        public Program(int id)
        {
            _registers["p"] = id;
        }

        public void Run(Program otherProgram)
        {
            var line = Input[_currentInstruction];
            var values = line.Split(' ');
            var instruction = values[0];
            var x = values[1];
            var y = values.Length == 3 ? values[2] : "0";
            var xValue = long.TryParse(x, out var vx) ? vx : _registers[x];
            var yValue = long.TryParse(y, out var vy) ? vy : _registers[y];

            switch (instruction)
            {
                case "snd":
                    otherProgram.MessageQueue.Enqueue(xValue);
                    ValuesSent++;
                    break;
                case "set":
                    _registers[x] = yValue;
                    break;
                case "add":
                    _registers[x] += yValue;
                    break;
                case "mul":
                    _registers[x] *= yValue;
                    break;
                case "mod":
                    _registers[x] %= yValue;
                    break;
                case "rcv" when MessageQueue.Any():
                    IsWaitingToReceiveInput = false;
                    _registers[x] = MessageQueue.Dequeue();
                    break;
                case "rcv" when !MessageQueue.Any():
                    IsWaitingToReceiveInput = true;
                    _currentInstruction--;
                    break;
                case "jgz" when xValue > 0L:
                    _currentInstruction += yValue - 1;
                    break;
            }

            _currentInstruction++;
        }
    }
}
