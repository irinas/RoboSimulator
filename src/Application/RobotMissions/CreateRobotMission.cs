using System.Text.Json.Serialization;
using RoboSimulator.Application.Common.Interfaces;
using RoboSimulator.Domain.Entities;
using Command = RoboSimulator.Domain.Entities.Command;

namespace RoboSimulator.Application.RobotMissions;
public record CreateRobotMissionCommand : IRequest<Execution>
{
    [JsonPropertyName("start")]
    public StartLocation Start { get; set; } = new StartLocation { X = 0, Y = 0 };

    [JsonPropertyName("commmands")]
    public List<Command> Commands { get; set; } = new List<Command>();
}

public class CreateRobotMissionCommandHandler : IRequestHandler<CreateRobotMissionCommand, Execution>
{
    private readonly IApplicationDbContext _context;

    public CreateRobotMissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Execution> Handle(CreateRobotMissionCommand request, CancellationToken cancellationToken)
    {        
        var startTime = DateTime.UtcNow;
        var result = SimulateCleaning.SimulateCleaningMission(request);
        var endTime = DateTime.UtcNow;
        
        //Prepare the result and store it in the table
        var execution = new Execution
        {
            Timestamp = endTime,
            Commands = request.Commands.Count,
            Result = result,
            Duration = (endTime - startTime).TotalSeconds
        };

        _context.Executions.Add(execution);
        await _context.SaveChangesAsync(cancellationToken);

        return execution;
    }

   
}
