using Microsoft.EntityFrameworkCore;
using NEFW.Practice.T01.Core.Entity;

namespace NEFW.Practice.T01.Core
{
    /// <summary>
    /// Represents the database context for employees and departments.
    /// </summary>
    public class EmployeeDepartmentDbContext : DbContext
    {
        /// <summary>
        /// Connection string for the database.
        /// </summary>
        private readonly string _ConnectionString = "Host=ep-jolly-scene-a15563c4.ap-southeast-1.aws.neon.tech;Database=Assignment1;Username=dquy1514;Password=I4U5QbdvWHnL";

        /// <summary>
        /// Gets or sets the DbSet for employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for departments.
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for Projects
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        /// <summary>
        /// Configures the options for the DbContext.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseNpgsql(_ConnectionString);
        }

        /// <summary>
        /// Configures the model relationships.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired();

            _ = modelBuilder.Entity<EmployeeProject>()
            .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            _ = modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.EmployeeId);

            _ = modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.ProjectId);

            _ = modelBuilder.Entity<Project>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Projects)
                .HasForeignKey(p => p.DepartmentId)
                .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
