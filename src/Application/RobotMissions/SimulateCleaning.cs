namespace RoboSimulator.Application.RobotMissions;
public static class SimulateCleaning
{  
    public static int SimulateCleaningMission(CreateRobotMissionCommand request)
    {
        var visitedPlaces = new HashSet<(int, int)>(); // Use a HashSet to ensure uniqueness
        
        int x = request.Start.X;
        int y = request.Start.Y;

        visitedPlaces.Add((x, y)); // Add the starting position

        foreach (var command in request.Commands)
        {
            int stepX = 0;
            int stepY = 0;

            switch (command.Direction)
            {
                case "north":
                    stepY = 1;
                    break;
                case "east":
                    stepX = 1;
                    break;
                case "south":
                    stepY = -1;
                    break;
                case "west":
                    stepX = -1;
                    break;
                default:
                    // Handle invalid directions
                    break;
            }


            for (int step = 0; step < command.Steps; step++)
            {
                x += stepX;
                y += stepY;
                var position = (x, y);

                visitedPlaces.Add(position); // Add returns true if the place is unique
            }
        }

        return visitedPlaces.Count;
    }

}
