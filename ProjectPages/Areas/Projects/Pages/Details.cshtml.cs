using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectPages.Data;
using TaskManagerLibrary.Models;

namespace ProjectPages.Areas.Project
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectPages.Data.ApplicationDbContext _context;

        public DetailsModel(ProjectPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ProjectModel ProjectModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProjectModel == null)
            {
                return NotFound();
            }

            var projectmodel = await _context.ProjectModel.FirstOrDefaultAsync(m => m.ProjectId == id);
            if (projectmodel == null)
            {
                return NotFound();
            }
            else 
            {
                ProjectModel = projectmodel;
            }
            return Page();
        }
    }
}
