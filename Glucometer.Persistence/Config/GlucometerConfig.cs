using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glucometer.Persistence.Config;

public class GlucometerConfig : IEntityTypeConfiguration<Domain.Entities.Glucometer>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Glucometer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsMany(u => u.GlucoseTests);
    }
}