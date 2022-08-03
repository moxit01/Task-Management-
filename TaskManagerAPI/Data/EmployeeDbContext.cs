using System;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskManagerAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) {
            Database.EnsureCreated();
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

