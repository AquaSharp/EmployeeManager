using EmployeeManager.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Guid)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Department>()
                .Property(d => d.Guid)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Employee>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Employee>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Department>()
                .Property(d => d.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Department>()
                .Property(d => d.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");


        }
    }
}
