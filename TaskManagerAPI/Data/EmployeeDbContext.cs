using System;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using TaskManagerLibrary.Models;

namespace TaskManagerAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) {
            Database.EnsureCreated();
        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<TaskModel> tasks { get; set; }
    }
}

