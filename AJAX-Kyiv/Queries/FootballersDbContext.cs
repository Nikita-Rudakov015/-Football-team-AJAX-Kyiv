using Microsoft.EntityFrameworkCore;
using Footballers.Application.Interfaces;
using AJAX_Kyiv.Domain;
using Footballers.Persistence.EntityTypeConfigurations;


namespace Footballers.Persistence
{
    public class FootballersDbContext : DbContext, IFootballersDbContext
    {
        public DbSet<Footballer> Footballers { get; set; }

        public FootballersDbContext(DbContextOptions<FootballersDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FootballerConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
