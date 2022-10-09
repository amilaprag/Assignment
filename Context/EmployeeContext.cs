using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    Name = "Test01"
                }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 2,
                    Name = "Test02"
                }
            );

            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Name = "dsdsdd",
                   DepartmentId = 1,
                   EmployeeId = 1,
                   Hours = 12.5M,
                   PayRate = 12.5M,
                   Title = "111"
               }
           );
        }

        public DbSet<Employee> Empoyee { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}