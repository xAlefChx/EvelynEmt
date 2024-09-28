using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.ProjectRequests;
using Evelyn.Application.Requests.UserProjectRequests;
using Evelyn.Application.Requests.UserRequests;
using Evelyn.Application.Services;
using Evelyn.Domain.Entities;
using Evelyn.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evelyn.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjectController : ControllerBase
    {
        private readonly IUserProjectServices _userProjectServices;

        public UserProjectController(IUserProjectServices userProjectServices)
        {
            _userProjectServices = userProjectServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProjectByIdAsync(int userprojectid)
        {
            var userproject = await _userProjectServices.GetUserProjectByIdAsync(userprojectid);
            if (userproject == null)
            {
                return NotFound();
            }

            return Ok(userproject);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllUserProjectsByIdAsync(Guid id)
        {
            var userproject = await _userProjectServices.GetAllUserProjectsByIdAsync(id);
            if (userproject == null)
            {
                return NotFound();
            }

            return Ok(userproject);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProject([FromBody]AddUserProjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUserProject = await _userProjectServices.CreateUserProjectAsync(request);
            return CreatedAtAction(nameof(CreateUserProject), new { id = newUserProject.Id }, newUserProject);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserProjectAsync(int userprojectid, [FromBody] UpdateUserProjectRequest request)
        {
            try
            {
                var updatedUserProject = await _userProjectServices.UpdateUserProjectAsync(userprojectid, request);
                return Ok(updatedUserProject);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _userProjectServices.GetUserProjectByIdAsync(userprojectid) == null)
                {
                    return NotFound();
                }

                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserProjectByIdAsync(int userprojectid)
        {
            var result = await _userProjectServices.DeleteUserProjectByIdAsync(userprojectid);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}