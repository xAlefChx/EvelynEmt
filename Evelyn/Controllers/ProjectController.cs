using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.ProjectRequests;
using Evelyn.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evelyn.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectServices _projectServices;

        public ProjectController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectServices.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(AddProjectRequest project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newProject = await _projectServices.CreateProjectAsync(project);
            return CreatedAtAction(nameof(CreateProject), new { id = newProject.Id }, newProject);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(int id, UpdateProjectRequest project)
        {
            try
            {
                var updatedProject = await _projectServices.UpdateProjectAsync( id, project);
                return Ok(updatedProject);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _projectServices.GetProjectByIdAsync(id) == null)
                {
                    return NotFound();
                }

                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectServices.DeleteProjectAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllProjectProductsByIdAsync(int projectid)
        {
            var products = await _projectServices.GetAllProjectProductsByIdAsync(projectid);
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("Address")]
        public async Task<IActionResult> GetAddressByProjectIdAsync(int projectid)
        {
            var address = await _projectServices.GetAddressByProjectIdAsync(projectid);
            if (address == null)
            {
                throw new ArgumentException("ProjectAddress not found");
            }
            return Ok(address);
        }
    }
}