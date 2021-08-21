using Entities = Course.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Course.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Course> Courses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
