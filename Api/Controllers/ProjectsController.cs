using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly DevForgeDbContext _context;

        public ProjectsController(DevForgeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            Project? project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(project);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project _project)
        {
            _context.Projects.Add(_project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = _project.Id }, _project);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project _project)
        {
            if (id != _project.Id)
            {
                return BadRequest();
            }
            try
            {
                _context.Entry(_project).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Projects.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            Project? project = await _context.Projects.FindAsync(id);

            if(project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

