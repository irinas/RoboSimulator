using System.Diagnostics;
using NUnit.Framework;
using RoboSimulator.Application.RobotMissions;
using RoboSimulator.Domain.Entities;

namespace RoboSimulator.Application.UnitTests;
public class RobotCleaningTests
{
    [Test]
    public void SimulateCleaning_ShouldReturnCorrectUniquePlaces()
    {
        // Arrange
        var request = new CreateRobotMissionCommand
        {
            Start = new StartLocation { X = 0, Y = 0 },
            Commands = new List<Command>()
            {
                    new Command { Direction = "north", Steps = 1 },
                    new Command { Direction = "east", Steps = 2 },
                    new Command { Direction = "north", Steps = 2 },
                    new Command { Direction = "west", Steps = 3 },
                    new Command { Direction = "east", Steps = 3 },
            }
        };

        // Act
        var uniquePlacesVisited = SimulateCleaning.SimulateCleaningMission(request);

        // Assert
        var expectedUniquePlaces = 9;
        Assert.That(uniquePlacesVisited, Is.EqualTo(expectedUniquePlaces));
    }

    [Test]
    public void SimulateCleaning_ShouldReturnOne_WhenNoCommandsGiven()
    {
        // Arrange
        var request = new CreateRobotMissionCommand
        {
            Start = new StartLocation { X = 0, Y = 0 },
            Commands = new List<Command>()
        };
        
        // Act
        var uniquePlacesVisited = SimulateCleaning.SimulateCleaningMission(request);

        // Assert
        Assert.That(uniquePlacesVisited, Is.EqualTo(1)); // Should only count the starting position
    }

    [Test]
    public void LoadTest_SimulateCleaningMission_WithLargeNumberOfCommands()
    {
        // Arrange
        var request = new CreateRobotMissionCommand
        {
            Start = new StartLocation { X = 0, Y = 0 },
            Commands = GenerateRobotCommands.GenerateRandomCommands(2000)
        };

        // Act
        var stopwatch = Stopwatch.StartNew(); // Start measuring time
        int result = SimulateCleaning.SimulateCleaningMission(request);
        stopwatch.Stop(); // Stop measuring time

        // Assert
        // Check if the elapsed time is less than 2 minutes
        Assert.IsTrue(stopwatch.ElapsedMilliseconds < 2*60000, 
            $"Method execution took too long: {stopwatch.ElapsedMilliseconds} milliseconds");


    }
}
