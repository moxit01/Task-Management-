// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TaskManagerLibrary;
using TaskManagerLibrary.Models;

namespace TaskManger.Areas.Identity.Pages.Account
{
    public class UserJson : IdentityUser
    {
        public string fullName { get; set; } = String.Empty;
        public string email { get; set; } = String.Empty;
    }

    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
         }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public EmployeeModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var values = new Dictionary<string, string>
                {
                    { "FullName", Input.FullName },
                    { "email", Input.Email },
                    { "password", Input.Password }
                 };

                var (status, responseString) = await TaskManagerLibrary.TaskManagerLibrary.SignUpRequest(values);

                if(status == 200)
                {
                    UserJson userObj = JsonSerializer.Deserialize<UserJson>(responseString);
                    userObj.UserName = userObj.email;
                    userObj.Email = userObj.email;

                    IdentityResult result = _userManager.CreateAsync(userObj, Input.Password).Result;

                    if (result.Succeeded)
                    {
                        //user saved in front end success
                        //show dashboard
                    }
                    else
                    {
                        //failure
                        //show local db error
                    }
                }
                else
                {
                    //show api error
                }
            }

            return Page();
        }
    }
}
