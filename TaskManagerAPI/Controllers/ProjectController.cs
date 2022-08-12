using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly EmployeeDbContext _context;

        // GET: api/values
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> Get(int id)
        {
            List<ProjectModel> projects = _context.Projects
                                .Include(p => p.Users) 
                                .ToList();

            return projects.FindAll(p => p.Users.Any(e => e.EmployeeId == id));
        }

        // POST api/values
        [HttpPost("create")]
        public async Task<ActionResult<ProjectModel>> Post(ProjectModel project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return Ok(project);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProjectModel project)
        {
            if (id != project.Id)
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
            return _context.Projects.Any(e => e.Id == id);
        }

    }
}

