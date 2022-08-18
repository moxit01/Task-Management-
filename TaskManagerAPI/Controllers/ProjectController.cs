using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Security.Claims;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTO;
using TaskManagerLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly EmployeeDbContext _context;

        // GET: api/values
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> Get(string id)
        {
            List<ProjectModel> projects = _context.Projects
                                .Include(p => p.Users) 
                                .ToList();

            return projects.FindAll(p => p.Users.Any(e => e.Id == id));
        }

        // POST api/values
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<ActionResult<ProjectModel>> Post(ProjectDto project)
        {
            EmployeeModel[] employees = new EmployeeModel[10];

            foreach (string id in project.Users)
            {
                EmployeeModel emp = new EmployeeModel
                {
                    Id = id
                };

                employees.Append(emp);
            }

            ProjectModel proj = new ProjectModel
            {
                Name = project.Name,
                Desc = project.Desc,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Users = employees
            };

            _context.Projects.Add(proj);
            await _context.SaveChangesAsync();

            return Ok(project);
        }

        // PUT api/values/5
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProjectModel project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest("Project Id and Id do not match.");
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound("Project not found.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(project);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound("Book not found.");
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }

        //private string GetUserId()
        //{
        //    return ((ClaimsIdentity)EmployeeModel.Identity).Claims.FirstOrDefault().Value;
        //}
    }
}

