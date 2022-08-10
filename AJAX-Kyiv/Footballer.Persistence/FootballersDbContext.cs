using Microsoft.EntityFrameworkCore;
using Footballers.Application.Interfaces;
using Footballers.Persistence.EntityTypeConfigurations;

namespace Footballer.Persistence
{
    public class FootballersDbContext : DbContext, IFootballersDbContext
    {
        public DbSet<AJAXKyiv.Domain.Footballer> Footballers { get; set; }

        public FootballersDbContext(DbContextOptions<FootballersDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FootballerConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
