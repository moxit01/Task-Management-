using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
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
            public string Email { get; set; } = String.Empty;
            public string id { get; set; } = String.Empty;
        }

        public class UserList
        {
            public UserJson[] Users { get; set; }
        }

        [BindProperty]
        public ProjectModel Input { get; set; }

        public UserJson[] users;
        public string[] selectedUserIds { get; set; } = Array.Empty<string>();
        public List<SelectListItem> listBoxArr = new List<SelectListItem> { };


        public IEnumerable<SelectListItem>? GetItems()
        {
            return new[]
            {
                new SelectListItem { Text = "user 1", Value  = "user 1"},
                new SelectListItem { Text = "user 2", Value  = "user 2"},
                new SelectListItem { Text = "user 3", Value  = "user 3"},
                new SelectListItem { Text = "user 4", Value  = "user 4"}
            };
        }

        private readonly ProjectPages.Data.ApplicationDbContext _context;

        public CreateModel(ProjectPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var responseString = await LibraryClass.GetUsers(Globals.AuthToken);

            var userList = Newtonsoft.Json.JsonConvert.DeserializeObject<UserList>(responseString);
            users = userList.Users;

            foreach (UserJson obj in users)
            {
                var item = new SelectListItem { Text = obj.Email, Value = obj.id };
                listBoxArr.Add(item);
            }

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

            var values = new Dictionary<string, object>
                {
                    { "name",  Input.Name},
                    { "Desc", Input.Desc },
                    { "StartDate", Input.StartDate },
                    { "EndDate", Input.EndDate},
                    { "Users", selectedUserIds }
                 };

            var (status, responseString) = await LibraryClass.CreateProjectRequest(values, Globals.AuthToken);

            if (status == 200)
            {

                return RedirectToPage("/Details", new { area = "Projects" });
                //return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
