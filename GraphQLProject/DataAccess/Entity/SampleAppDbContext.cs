using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.DataAccess.Entity
{
    public class SampleAppDbContext : DbContext
    {
        public SampleAppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
