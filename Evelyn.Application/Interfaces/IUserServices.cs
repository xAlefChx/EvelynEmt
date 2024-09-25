using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evelyn.Application.Requests.UserRequests;
using Evelyn.Domain.Entities;

namespace Evelyn.Application.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> CreateUserAsync(AddUserRequest request);
        Task<User> UpdateUserAsync(Guid id, UpdateUserRequest request);
        Task<bool> DeleteUserAsync(Guid id);
        Task<User> AddUserRoleAsync(AddUserRoleRequest request);
        Task<bool> DeleteUserRoleAsync(Guid id);
    }
}
