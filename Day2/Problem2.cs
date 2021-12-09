using System;
using System.Collections.Generic;

namespace AdventOfCode.Day2
{
    class Problem2
    {
        static void OldMain()
        {
            var position = ProcessCommands(PuzzleInput.Data);

            Console.WriteLine($"Final position: {position.Horizontal}, {position.Depth}. Multiplied: {position.Horizontal * position.Depth}.");
        }

        static (int Horizontal, int Depth) ProcessCommands(IList<string> commands)
        {
            var horizontal = 0;
            var depth = 0;
            var aim = 0;

            foreach (var command in commands)
            {
                var (direction, movement) = ParseCommand(command);

                if (direction == Direction.Up) aim -= movement;
                if (direction == Direction.Down) aim += movement;
                if (direction == Direction.Forward) 
                {
                    horizontal += movement;
                    depth += aim * movement;
                }
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