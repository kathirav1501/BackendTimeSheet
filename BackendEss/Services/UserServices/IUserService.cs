using BackendEss.Dtos.User;
using BackendEss.Model;
using Microsoft.AspNetCore.Mvc;

namespace BackendEss.Services.UserServices
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDTO>>> GetUsers();
        Task<ServiceResponse<List<UserTaskDTO>>> GetAllUsersTasksWithProjects();
        Task<ServiceResponse<List<UserTaskDTO>>> GetUserTasksWithProjects(int UserID);
    }
}
