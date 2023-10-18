using RoboSimulator.Application.RobotMissions;

namespace RoboSimulator.Application.RobotMissions;

public class CreateRobotMissionCommandValidator : AbstractValidator<CreateRobotMissionCommand>
{
    public CreateRobotMissionCommandValidator()
    {
        RuleFor(v => v.Start.X)
            .LessThanOrEqualTo(100000)
            .GreaterThanOrEqualTo(-100000);

        RuleFor(v => v.Start.Y)
            .LessThanOrEqualTo(100000)
            .GreaterThanOrEqualTo(-100000);

        RuleFor(v => v.Commands)
            .Must(v => v.Count <= 10000)
            .WithMessage("Number of commands shoud be <= 10000.");

        RuleForEach(v => v.Commands)
            .Must((v, command) =>
                command.Direction == "north"
                || command.Direction == "south"
                || command.Direction == "east"
                || command.Direction == "west")
            .WithMessage("Direction must be north, south, east or west. Case sensitive."); 
    }
}
