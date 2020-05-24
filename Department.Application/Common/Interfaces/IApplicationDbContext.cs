using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Department.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Department> Departments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
