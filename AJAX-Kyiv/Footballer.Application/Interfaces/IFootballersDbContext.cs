using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AJAX_Kyiv.Domain;
using System.Threading;

namespace Footballers.Application.Interfaces
{
    public interface IFootballersDbContext
    {
        DbSet<Footballer> Footballers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
