using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebAPI.Model;

namespace WebAPI.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee > Employees { get; set; }

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
