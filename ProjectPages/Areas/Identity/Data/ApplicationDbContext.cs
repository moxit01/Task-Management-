using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectPages.Models;


namespace ProjectPages.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    // public DbSet<TaskManager.Models.Project>? Project { get; set; }

    //public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Employee> Employees  => Set<Employee>();
    public DbSet<EmployeeProject> Projects => Set<EmployeeProject>();
   //public DbSet<TaskModel> Tasks { get; set; }
}
