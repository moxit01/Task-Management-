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
    public class TaskController : Controller
    {
        private readonly EmployeeDbContext _context;

        // GET: api/values
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TaskModel>>> Get(int id)
        {
            List<TaskModel> tasks = _context.Tasks
                                .Include(t => t.Project)
                                .ToList();

            return tasks.FindAll(t => t.Project.Id == id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<TaskModel>> Post(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(task);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskModel task)
        {
            if (id != task.Id)
            {
                return BadRequest("TaskId and Id do not match.");
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound("Task not found.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(task);
        }

        private bool TaskExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }

    }
}


