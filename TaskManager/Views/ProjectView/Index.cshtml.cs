using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManger.Views.ProjectView
{
    public class IndexModel : PageModel
    {
        private readonly TaskManager.Data.ApplicationDbContext _context;

        public IndexModel(TaskManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EmployeeProject> EmployeeProject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Projects != null)
            {
                EmployeeProject = await _context.Projects.ToListAsync();
            }
        }
    }
}
