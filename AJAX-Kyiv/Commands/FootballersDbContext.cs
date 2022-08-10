using Microsoft.EntityFrameworkCore;
using Footballers.Application.Interfaces;
using Footballers.Persistence.EntityTypeConfigurations;


namespace Footballers.Persistence
{
    public class FootballersDbContext : DbContext, IFootballersDbContext
    {
        public DbSet<AJAXKyiv.Domain.Footballer> Footballers { get; set; }
    }
}
