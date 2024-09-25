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

        [HttpGet(nameof(GetAllUserAddresses))]
        public async Task<IActionResult> GetAllUserAddresses(Guid id)
        {
            var Addresses = await _AddressServices.GetAllUserAddressesAsync(id);
            return Ok(Addresses);
        }

        [HttpGet("{id}"+ (nameof(GetUserAddressById)))]
        public async Task<IActionResult> GetUserAddressById(int id)
        {
            var Address = await _AddressServices.GetUserAddressByIdAsync(id);
            if (Address == null)
            {
                return NotFound();
            }

            return Ok(Address);
        }

        [HttpPost(nameof(AddUserAddress))]
        public async Task<IActionResult> AddUserAddress(Guid id, AddUserAddressRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUserAddress = await _AddressServices.CreateUserAddressAsync(id ,request);
            return CreatedAtAction(nameof(AddUserAddress), new { id = newUserAddress.Id }, newUserAddress);
        }

        [HttpPut("{id}"+(nameof(UpdateUserAddress)))]
        public async Task<IActionResult> UpdateUserAddress(int id, UpdateUserAddressRequest request)
        {
            try
            {
                var updatedUserAddress = await _AddressServices.UpdateUserAddressAsync(id, request);
                return Ok(updatedUserAddress);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _AddressServices.GetUserAddressByIdAsync(id) == null)
                {
                    return NotFound();
                }

                throw;
            }
        }

        [HttpDelete("{id}"+(nameof(DeleteUserAddress)))]
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