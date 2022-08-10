using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using AJAXKyiv.Domain;

namespace Footballers.Application.Interfaces
{
    public interface IFootballersDbContext
    {
        DbSet<Footballer> Footballers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
