using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectPages.Data;
using TaskManagerLibrary.Models;

namespace ProjectPages.Areas.Tasks
{
    public class CreateModel : PageModel
    {
        private readonly ProjectPages.Data.ApplicationDbContext _context;

        public CreateModel(ProjectPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaskModel TaskModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tasks == null || TaskModel == null)
            {
                return Page();
            }

            _context.Tasks.Add(TaskModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
