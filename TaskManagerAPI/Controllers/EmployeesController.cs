using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TaskManagerAPI.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using TaskManagerAPI.Models;
using BookStoreAPI.Helpers;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerAPI.Controllers
{

    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {

        private readonly ILogger<EmployeesController> logger;
        private readonly SignInManager<Employee> signInManager;
        private readonly UserManager<Employee> userManager;
        private readonly IConfiguration config;

        public EmployeesController(ILogger<EmployeesController> logger,
    SignInManager<Employee> signInManager,
    UserManager<Employee> userManager,
    IConfiguration config)
        {
            this.logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.config = config;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await this.userManager.FindByEmailAsync(model.Email);
                if (existingUser == null)
                {
                    Employee user = new Employee();
                    user.FullName = model.FullName;
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    IdentityResult result = userManager.CreateAsync(user, model.Password).Result;

                    if (result.Succeeded)
                    {
                        Response.Headers.Add("Authorization", JWTHelper.generateToken(user, this.config));
                        return Ok(new
                        {
                            fullName = user.FullName,
                            email = user.Email,
                        });
                    }
                    else
                    {
                        string errors = "";
                        foreach (IdentityError e in result.Errors)
                        {
                            errors += $"{e.Description} ";
                        }
                        errors = errors.TrimEnd();
                        return Problem(detail: errors, statusCode: (int)HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    return Problem(detail: "User already exists.", statusCode: (int)HttpStatusCode.Conflict);
                }

            }

            return BadRequest();
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManager.FindByNameAsync(model.Email);
                //var user = await this.userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var passwordCheck = await this.signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (passwordCheck.Succeeded)
                    {
                        Response.Headers.Add("Authorization", JWTHelper.generateToken(user, this.config));
                        return Ok(new
                        {
                            fullName = user.FullName,
                            email = user.Email,
                        });
                    }
                    else
                    {
                        return Unauthorized("Your password is incorrect.");
                    }
                }
                else
                {
                    return NotFound("User not exist.");
                }
            }

            return BadRequest();
        }
    }
}

