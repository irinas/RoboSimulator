using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboSimulator.Domain.Entities;

namespace RoboSimulator.Infrastructure.Data.Configurations;
public class ExecutionConfiguration : IEntityTypeConfiguration<Execution>
{
    public void Configure(EntityTypeBuilder<Execution> builder)
    {
        builder.Property(t => t.Id)
            .UseIdentityColumn();

        builder.Property(t => t.Timestamp)
            .IsRequired();

        builder.Property(t => t.Duration)
            .IsRequired();

        builder.Property(t => t.Commands)
            .IsRequired();
    }
}
