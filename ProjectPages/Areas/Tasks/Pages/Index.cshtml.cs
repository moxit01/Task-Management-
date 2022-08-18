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
    public class IndexModel : PageModel
    {
        private readonly ProjectPages.Data.ApplicationDbContext _context;

        public IndexModel(ProjectPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskModel> TaskModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tasks != null)
            {
               // TaskModel = await _context.Tasks.ToListAsync();
            }
        }
    }
}
