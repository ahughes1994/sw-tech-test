using Microsoft.EntityFrameworkCore;

namespace SWCodeReview
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }
    }
}
