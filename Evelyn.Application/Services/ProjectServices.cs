using Azure.Core;
using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.ProjectRequests;
using Evelyn.Domain.Entities;
using Evelyn.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using static Evelyn.Domain.Enums.Enums;

namespace Evelyn.Application.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly Context _context;

        public ProjectServices(Context context)
        {
            _context = context;
        }

        public async Task<Project> CreateProjectAsync(AddProjectRequest request)
        {
            Project project = new Project()
            {
                Type = request.Type,
                Status = ProjectStatus.NotStarted,
                DateOfProject = request.DateOfProject,
                AddressId = request.AddressId,
            };
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return false;
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProjectProductsByIdAsync(int projectid)
        {
            return await _context.Products.Where(p=> p.ProjectId == projectid).ToListAsync();
        }

        public async Task<Address> GetAddressByProjectIdAsync(int projectid)
        {
            var project = await _context.Projects
                    .Include(p => p.Address)
                    .FirstOrDefaultAsync(p => p.Id == projectid);

            if (project == null)
            {
                throw new ArgumentException("Project not found");
            }

            return project.Address;
        }
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project> UpdateProjectAsync(int id ,UpdateProjectRequest request)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }
            
            project.DateOfProject = request.DateOfProject;
            project.Type = request.Type;
            project.Status = request.Status;
            project.AddressId = request.AddressId;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }
    }
}