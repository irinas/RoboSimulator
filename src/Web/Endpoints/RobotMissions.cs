using Microsoft.AspNetCore.Mvc;
using RoboSimulator.Application.RobotMissions;
using RoboSimulator.Domain.Entities;

namespace RoboSimulator.Web.Endpoints;

public class RobotMissions : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateRobotMission);
    }

    public async Task<Execution> CreateRobotMission(ISender sender, CreateRobotMissionCommand command)
    {
        return await sender.Send(command);
    }

}
