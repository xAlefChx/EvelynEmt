using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.AddressRequest;
using Evelyn.Domain.Entities;
using Evelyn.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Evelyn.Application.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly Context _context;

        public AddressServices(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAllUserAddressesAsync(Guid userid)
        {
            return await _context.Addresses.Where(a => a.UserId == userid).ToListAsync();
        }

        public async Task<Address> GetUserAddressByIdAsync(int addressid)
        {
            return await _context.Addresses.FindAsync(addressid);
        }

        public async Task<Address> CreateUserAddressAsync(Guid id , AddUserAddressRequest request)
        {
            Address address = new Address()
            {
                CityId = request.CityId,
                ProvinceId = request.ProvinceId,
                MainAddress = request.MainAddress,
                ZipCode = request.ZipCode,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                UserId = id
            };
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateUserAddressAsync(int id, UpdateUserAddressRequest request)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                throw new Exception("Address not found");
            }
            address.CityId = request.CityId;
            address.ProvinceId = request.ProvinceId;
            address.MainAddress = request.MainAddress;
            address.ZipCode = request.ZipCode;
            address.Latitude = request.Latitude;
            address.Longitude = request.Longitude;

            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<bool> DeleteUserAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return false;
            }
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
