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
    public class DetailsModel : PageModel
    {
        private readonly TaskManager.Data.ApplicationDbContext _context;

        public DetailsModel(TaskManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public EmployeeProject EmployeeProject { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var employeeproject = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);
            if (employeeproject == null)
            {
                return NotFound();
            }
            else 
            {
                EmployeeProject = employeeproject;
            }
            return Page();
        }
    }
}
