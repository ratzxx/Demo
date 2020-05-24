using System.Linq;
using System.Threading.Tasks;

namespace Department.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Departments.Any())
            {
                context.Departments.Add(new Domain.Entities.Department
                {
                    Title = "IT department"
                });

                context.Departments.Add(new Domain.Entities.Department
                {
                    Title = "Marketing"
                });


                await context.SaveChangesAsync();
            }
        }
    }
}
