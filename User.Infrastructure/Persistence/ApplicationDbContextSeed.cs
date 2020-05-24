using System.Linq;
using System.Threading.Tasks;

namespace User.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new Domain.Entities.User
                {
                    UserName = "johnny81",
                    DepartmentId = 1
                });

                context.Users.Add(new Domain.Entities.User
                {
                    UserName = "missmary",
                    DepartmentId = 2
                });

                context.Users.Add(new Domain.Entities.User
                {
                    UserName = "jijames",
                    DepartmentId = 1
                });


                await context.SaveChangesAsync();
            }
        }
    }
}
