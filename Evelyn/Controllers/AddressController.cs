using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.AddressRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evelyn.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly IAddressServices _AddressServices;

        public AddressController(IAddressServices addressServices)
        {
            _AddressServices = addressServices;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllUserAddresses(Guid id)
        {
            var Addresses = await _AddressServices.GetAllUserAddressesAsync(id);
            return Ok(Addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAddressById(int id)
        {
            var Address = await _AddressServices.GetUserAddressByIdAsync(id);
            if (Address == null)
            {
                return NotFound();
            }

            return Ok(Address);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAddress(Guid id, AddUserAddressRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUserAddress = await _AddressServices.CreateUserAddressAsync(id, request);
            return CreatedAtAction(nameof(AddUserAddress), new { id = newUserAddress.Id }, newUserAddress);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAddress(int id, UpdateUserAddressRequest request)
        {
            var updatedUserAddress = await _AddressServices.UpdateUserAddressAsync(id, request);
            return Ok(updatedUserAddress);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAddress(int id)
        {
            var result = await _AddressServices.DeleteUserAddressAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}