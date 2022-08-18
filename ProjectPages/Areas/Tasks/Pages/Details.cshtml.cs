using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectPages.Data;
using TaskManagerLibrary.Models;

namespace ProjectPages.Areas.Tasks
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectPages.Data.ApplicationDbContext _context;

        public DetailsModel(ProjectPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public TaskModel TaskModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var taskmodel = await _context.Tasks.FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskmodel == null)
            {
                return NotFound();
            }
            else 
            {
                TaskModel = taskmodel;
            }
            return Page();
        }
    }
}
