using RoboSimulator.Domain.Entities;

namespace RoboSimulator.Application.UnitTests;
internal static class GenerateRobotCommands
{
    public static List<Command> GenerateRandomCommands(int count)
    {
        var random = new Random();
        var commands = new List<Command>(count);

        for (int i = 0; i < count; i++)
        {
            int directionIndex = random.Next(4); // Generate a random number between 0 and 3
            string direction;

            switch (directionIndex)
            {
                case 0:
                    direction = "north";
                    break;
                case 1:
                    direction = "east";
                    break;
                case 2:
                    direction = "south";
                    break;
                case 3:
                    direction = "west";
                    break;
                default:
                    direction = "unknown";
                    break;
            }

            int steps = random.Next(1, 50000); // Generate a random number of steps between 1 and 50000

            commands.Add(new Command { Direction = direction, Steps = steps });
        }

        return commands;
    }
}
