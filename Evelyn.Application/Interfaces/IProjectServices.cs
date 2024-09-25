using Evelyn.Application.Requests.ProjectRequests;
using Evelyn.Domain.Entities;

namespace Evelyn.Application.Interfaces
{
    public interface IProjectServices
    {
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> CreateProjectAsync(AddProjectRequest request);
        Task<Project> UpdateProjectAsync(int id, UpdateProjectRequest request);
        Task<bool> DeleteProjectAsync(int id);
        Task<List<Product>> GetAllProjectProductsByIdAsync(int projectid);
        Task<Address> GetAddressByProjectIdAsync(int projectid);
    }
}
