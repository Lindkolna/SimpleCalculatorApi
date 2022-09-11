using Microsoft.EntityFrameworkCore;

namespace MinimalApiCalculator
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Calculator> Calculators => Set<Calculator>();
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {

        }
    }
}
