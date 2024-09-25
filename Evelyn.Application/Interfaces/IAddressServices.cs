using Evelyn.Application.Requests.AddressRequest;
using Evelyn.Domain.Entities;

namespace Evelyn.Application.Interfaces
{
    public interface IAddressServices
    {
        Task<IEnumerable<Address>> GetAllUserAddressesAsync(Guid userid);
        Task<Address> GetUserAddressByIdAsync(int addressid);
        Task<Address> CreateUserAddressAsync(Guid id, AddUserAddressRequest request);
        Task<Address> UpdateUserAddressAsync(int id, UpdateUserAddressRequest request);
        Task<bool> DeleteUserAddressAsync(int id);
    }
}
