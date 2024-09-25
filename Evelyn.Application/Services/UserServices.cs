using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.UserRequests;
using Evelyn.Domain.Entities;
using Evelyn.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using static Evelyn.Application.Services.UserServices;

namespace Evelyn.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly Context _context;

        public UserServices(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> CreateUserAsync(AddUserRequest request)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CoinScore = 0,
                MatterType = request.MatterType,
                NationalId = request.NationalId,
                PhoneNumber = request.PhoneNumber,
                Role = Domain.Enums.Enums.RoleType.User,
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUserAsync(Guid id, UpdateUserRequest request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Name = request.Name;
            user.MatterType = request.MatterType;
            user.NationalId = request.NationalId;
            user.PhoneNumber = request.PhoneNumber;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> AddUserRoleAsync(AddUserRoleRequest request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Role = request.Role;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserRoleAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Role = Domain.Enums.Enums.RoleType.User;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}