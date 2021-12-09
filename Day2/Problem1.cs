using System;
using System.Collections.Generic;

namespace AdventOfCode.Day2
{
    class Problem1
    {
        static void Main()
        {
            var position = ProcessCommands(PuzzleInput.Data);

            Console.WriteLine($"Final position: {position.Horizontal}, {position.Depth}. Multiplied: {position.Horizontal * position.Depth}.");
        }

        static (int Horizontal, int Depth) ProcessCommands(IList<string> commands)
        {
            var horizontal = 0;
            var depth = 0;

            foreach (var command in commands)
            {
                var (direction, movement) = ParseCommand(command);

                if (direction == Direction.Up) depth -= movement;
                if (direction == Direction.Down) depth += movement;
                if (direction == Direction.Forward) horizontal += movement;
            }

            return (horizontal, depth);
        }

        static (Direction Direction, int Movement) ParseCommand(string command)
        {
            var parts = command.Split(' ');

            var direction = parts[0] switch
            {
                "forward" => Direction.Forward,
                "down" => Direction.Down,
                "up" => Direction.Up,
                _ => throw new ArgumentOutOfRangeException("parts[0]", $"Can't parse \"{parts[0]}\"")
            };

            if (!int.TryParse(parts[1], out var movement))
            {
                throw new ArgumentOutOfRangeException("parts[1]", $"Can't turn \"{parts[1]}\" into an int");
            }

            return (direction, movement);
        }
    }
}