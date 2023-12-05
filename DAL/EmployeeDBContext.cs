using EmployeeData.Models.DBEntity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.DAL
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {
        }

        //Create data set for employee class,Employee table will called every CRUD operations
        public DbSet<Employee> Employees { get; set; }
    }
}
