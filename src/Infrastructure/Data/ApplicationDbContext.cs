using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RoboSimulator.Application.Common.Interfaces;
using RoboSimulator.Domain.Entities;

namespace RoboSimulator.Infrastructure.Data;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Execution> Executions => Set<Execution>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
