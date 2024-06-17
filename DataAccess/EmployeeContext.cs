using Microsoft.EntityFrameworkCore;
using SWCodeReview.Models;

namespace SWCodeReview.DataAccess
{
    public class EmployeeContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }
    }
}
