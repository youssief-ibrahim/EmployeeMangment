using EmployeeMangment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangment.Data
{
    public class ApplecationDbContext:DbContext
    {
        public ApplecationDbContext(DbContextOptions<ApplecationDbContext> options) : base(options)
        {
        }
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }


    }
}
