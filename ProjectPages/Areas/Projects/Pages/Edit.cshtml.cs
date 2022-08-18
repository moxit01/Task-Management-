using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectPages.Data;
using TaskManagerLibrary.Models;

namespace ProjectPages.Areas.Project
{
    public class EditModel : PageModel
    {
        private readonly ProjectPages.Data.ApplicationDbContext _context;

        public EditModel(ProjectPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProjectModel ProjectModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProjectModel == null)
            {
                return NotFound();
            }

            var projectmodel =  await _context.ProjectModel.FirstOrDefaultAsync(m => m.ProjectId == id);
            if (projectmodel == null)
            {
                return NotFound();
            }
            ProjectModel = projectmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProjectModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectModelExists(ProjectModel.ProjectId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectModelExists(int id)
        {
          return (_context.ProjectModel?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}
