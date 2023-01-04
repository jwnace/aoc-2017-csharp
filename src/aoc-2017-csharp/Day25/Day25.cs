namespace aoc_2017_csharp.Day25;

public static class Day25
{
    public static int Part1()
    {
        var tape = new Dictionary<int, int>();
        var currentPosition = 0;
        var currentState = State.A;
        var steps = 12_523_873;
        
        for (var i = 0; i < steps; i++)
        {
            var currentValue = tape.TryGetValue(currentPosition, out var value) ? value : 0;

            switch (currentState)
            {
                case State.A when currentValue == 0:
                    tape[currentPosition] = 1;
                    currentPosition++;
                    currentState = State.B;
                    break;
                case State.A when currentValue == 1:
                    tape[currentPosition] = 1;
                    currentPosition--;
                    currentState = State.E;
                    break;
                case State.B when currentValue == 0:
                    tape[currentPosition] = 1;
                    currentPosition++;
                    currentState = State.C;
                    break;
                case State.B when currentValue == 1:
                    tape[currentPosition] = 1;
                    currentPosition++;
                    currentState = State.F;
                    break;
                case State.C when currentValue == 0:
                    tape[currentPosition] = 1;
                    currentPosition--;
                    currentState = State.D;
                    break;
                case State.C when currentValue == 1:
                    tape[currentPosition] = 0;
                    currentPosition++;
                    currentState = State.B;
                    break;
                case State.D when currentValue == 0:
                    tape[currentPosition] = 1;
                    currentPosition++;
                    currentState = State.E;
                    break;
                case State.D when currentValue == 1:
                    tape[currentPosition] = 0;
                    currentPosition--;
                    currentState = State.C;
                    break;
                case State.E when currentValue == 0:
                    tape[currentPosition] = 1;
                    currentPosition--;
                    currentState = State.A;
                    break;
                case State.E when currentValue == 1:
                    tape[currentPosition] = 0;
                    currentPosition++;
                    currentState = State.D;
                    break;
                case State.F when currentValue == 0:
                    tape[currentPosition] = 1;
                    currentPosition++;
                    currentState = State.A;
                    break;
                case State.F when currentValue == 1:
                    tape[currentPosition] = 1;
                    currentPosition++;
                    currentState = State.C;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return tape.Values.Count(v => v == 1);
    }

    public static string Part2() => "Merry Christmas!";

    private enum State
    {
        A,
        B,
        C,
        D,
        E,
        F,
    }
}
