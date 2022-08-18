using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectPages.Areas.Identity.Data;
using ProjectPages.Data;
using TaskManagerLibrary;
using TaskManagerLibrary.Models;

namespace ProjectPages.Areas.Project
{
    public class CreateModel : PageModel
    {
        public class UserJson
        {
            public string fullName { get; set; } = String.Empty;
            public string id { get; set; } = String.Empty;
        }

        public class UserList
        {
            public UserJson[] Users { get; set; }
        }

        public UserList users;

        private readonly ProjectPages.Data.ApplicationDbContext _context;

        public CreateModel(ProjectPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var responseString = await LibraryClass.GetUsers(Globals.AuthToken);

            users = Newtonsoft.Json.JsonConvert.DeserializeObject<UserList>(responseString);

            return Page();
        }

        [BindProperty]
        public ProjectModel ProjectModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProjectModel == null || ProjectModel == null)
            {
                return Page();
            }

            _context.ProjectModel.Add(ProjectModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
