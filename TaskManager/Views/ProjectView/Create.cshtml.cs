using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManger.Views.ProjectView
{
    public class CreateModel : PageModel
    {
        private readonly TaskManager.Data.ApplicationDbContext _context;

        public CreateModel(TaskManager.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmployeeProject EmployeeProject { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Projects == null || EmployeeProject == null)
            {
                return Page();
            }

            _context.Projects.Add(EmployeeProject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
