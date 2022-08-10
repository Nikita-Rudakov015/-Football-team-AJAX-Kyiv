using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Footballers.Application.Interfaces
{
    public interface IFootballersDbContext
    {
        DbSet<AJAXKyiv.Domain.Footballer> Footballers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
