using Azure.Core;
using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.ProjectRequests;
using Evelyn.Application.Requests.UserProjectRequests;
using Evelyn.Application.Requests.UserRequests;
using Evelyn.Domain.Entities;
using Evelyn.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Evelyn.Application.Services
{
    public class UserProjectServices : IUserProjectServices
    {
        private readonly Context _context;

        public UserProjectServices(Context context)
        {
            _context = context;
        }

        public async Task<UserProject> CreateUserProjectAsync(AddUserProjectRequest request)
        {
            UserProject userproject = new UserProject()
            {
                UserId = request.UserId,
                UserInChargeId = request.UserInChargeId,
                UserTechId = request.UserTechId,
                ProjectId = request.ProjectId,
            };
            await _context.UserProject.AddAsync(userproject);
            await _context.SaveChangesAsync();
            return userproject;
        }
        public async Task<bool> DeleteUserProjectByIdAsync(int userprojectid)
        {
            var userproject = await _context.UserProject.FindAsync(userprojectid);
            if (userproject == null)
            {
                return false;
            }
            _context.UserProject.Remove(userproject);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserProject>> GetAllUserProjectsByIdAsync(Guid id)
        {
            return await _context.UserProject.Where(u=> u.UserId == id).ToListAsync();
        }

        public async Task<UserProject> GetUserProjectByIdAsync(int userprojectid)
        {
            return await _context.UserProject.FindAsync(userprojectid);
        }
        public async Task<UserProject> UpdateUserProjectAsync(int userprojectid, UpdateUserProjectRequest request)
        {
            var userproject = await _context.UserProject.FindAsync(userprojectid);
            if (userproject == null)
            {
                throw new Exception("UserProject not found");
            }
            userproject.ProjectId = request.ProjectId;
            userproject.UserInChargeId = request.UserInChargeId;
            userproject.UserTechId = request.UserTechId;
            userproject.UserId = request.UserId;

            _context.UserProject.Update(userproject);
            await _context.SaveChangesAsync();
            return userproject;
        }
    }
}