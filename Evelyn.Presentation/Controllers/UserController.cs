using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.UserRequests;
using Evelyn.Domain.Entities;
using Evelyn.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Evelyn.Application.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServices _userServices;

        public UserController(IUserServices userService)
        {
            _userServices = userService;
        }

        [HttpGet(nameof(GetAllUsers))]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userServices.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}/" + nameof(GetUserById))]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost(nameof(AddUser))]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = await _userServices.CreateUserAsync(user);
            return CreatedAtAction(nameof(AddUser), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}" + nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserRequest user)
        {
            try
            {
                var updatedUser = await _userServices.UpdateUserAsync( id ,user);
                return Ok(updatedUser);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _userServices.GetUserByIdAsync(id) == null)
                {
                    return NotFound();
                }

                throw;
            }
        }

        [HttpDelete("{id}" + nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _userServices.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost(nameof(AddUserRole))]
        public async Task<IActionResult> AddUserRole([FromBody] AddUserRoleRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = await _userServices.AddUserRoleAsync(user);
            return CreatedAtAction(nameof(AddUserRole), new { id = newUser.Id }, newUser);
        }

        [HttpDelete("{id}" + nameof(DeleteUserRole))]
        public async Task<IActionResult> DeleteUserRole(Guid id)
        {
            var result = await _userServices.DeleteUserRoleAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}