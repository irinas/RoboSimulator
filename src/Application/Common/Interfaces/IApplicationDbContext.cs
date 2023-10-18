using RoboSimulator.Domain.Entities;

namespace RoboSimulator.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Execution> Executions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
