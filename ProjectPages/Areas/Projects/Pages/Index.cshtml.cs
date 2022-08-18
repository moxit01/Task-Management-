using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectPages.Areas.Identity.Data;
using ProjectPages.Data;
using TaskManagerLibrary;
using TaskManagerLibrary.Models;

namespace ProjectPages.Areas.Project
{
    public class IndexModel : PageModel
    {
        public class ProjectJson
        {
            public string Name { get; set; } = String.Empty;
            public string Desc { get; set; } = String.Empty;
            public string StartDate { get; set; } = String.Empty;
            public string EndDate { get; set; } = String.Empty;
            public string id { get; set; } = String.Empty;
        }

        public class ProjectList
        {
            public ProjectJson[] Projects { get; set; }
        }

        public ProjectJson[] projects;

        private readonly ProjectPages.Data.ApplicationDbContext _context;

        public IndexModel(ProjectPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            var (status, responseString) = await LibraryClass.GetAllProjects(Globals.AuthToken, Globals.id);

            if (status == 200)
            {
                var obj = JsonConvert.DeserializeObject<ProjectModel>(responseString);
                var projectList = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectList>(responseString);

                projects = projectList.Projects;
            }
        }
    }
}
