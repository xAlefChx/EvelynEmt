using Evelyn.Application.Requests.UserProjectRequests;
using Evelyn.Application.Requests.UserRequests;
using Evelyn.Domain.Entities;

namespace Evelyn.Application.Interfaces
{
    public interface IUserProjectServices
    {
        Task<UserProject> CreateUserProjectAsync(AddUserProjectRequest request);
        Task<UserProject> UpdateUserProjectAsync(int userprojectid , UpdateUserProjectRequest request);
        Task<bool> DeleteUserProjectByIdAsync(int userprojectid);
        Task<UserProject> GetUserProjectByIdAsync(int userprojectid);
        Task<List<UserProject>> GetAllUserProjectsByIdAsync(Guid id);

    }
}