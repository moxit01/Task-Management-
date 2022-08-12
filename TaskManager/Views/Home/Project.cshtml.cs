using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManager.Models;

namespace TaskManger.Views.Home
{
    public class UserJson : IdentityUser
    {
        public string Name { get; set; } = String.Empty;
        public string Desc { get; set; } = String.Empty;
    }

    public class ProjectModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ProjectModel> _logger;

       

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public Employee Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }


    }
}
