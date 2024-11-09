using Glucometer.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace Glucometer.Persistence;
public class GlucometerDbContext : DbContext
{
    public GlucometerDbContext(DbContextOptions<GlucometerDbContext> options) : base(options) { }

    public DbSet<Domain.Entities.Glucometer> Glucometers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Domain.Entities.Glucometer>(new GlucometerConfig());
    }
}