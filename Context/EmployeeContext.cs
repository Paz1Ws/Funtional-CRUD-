using FinalBackendProject.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Migrations;
namespace FinalBackendProject.Context
{
    public class EmployeeContext : DbContext
    {
        
            public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
            {
            }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<EmployeeDTO> EmployeesDTO { get; set; }
       
    }
}
