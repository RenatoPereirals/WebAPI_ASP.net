using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Model.CompanyAggregate;
using WebAPI.Domain.Model.EmployeeAggregate;

namespace WebAPI.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee > Employees { get; set; }
        public DbSet<Company > Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql
            (
                "Server=localhost;" +
                "Port=5432;Database=employee;" +
                "User Id=postgres;" +
                "Password=RPS532110nat;"
            );
    }
}
