using AutoMapper;
using BackendEss.DBContext;
using BackendEss.Dtos.Project;
using BackendEss.Dtos.Tasks;
using BackendEss.Dtos.User;
using BackendEss.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendEss.Services.UserServices
{

    public class UserService : IUserService
    {
        private readonly EssDBContext _context;
        private readonly IMapper _mapper;
        public UserService(EssDBContext essDBContext , IMapper mapper)
        {
            _context = essDBContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<UserTaskDTO>>> GetAllUsersTasksWithProjects()
        {
            var response = new ServiceResponse<List<UserTaskDTO>>();

            try
            {
                var users = await _context.AppUsers.ToListAsync(); // Fetch all users asynchronously

                var userTaskDTOs = new List<UserTaskDTO>();

                foreach (var user in users)
                {
                    var userTasks = await _context.Tasks
                        .Include(t => t.Project)
                        .Where(t => t.UserID == user.UserID)
                        .ToListAsync(); // Fetch all tasks for the user asynchronously

                    var userTaskDTO = _mapper.Map<UserTaskDTO>(user);
                    userTaskDTO.Tasks = _mapper.Map<ICollection<TaskDTO>>(userTasks);

                    foreach (var taskDto in userTaskDTO.Tasks)
                    {
                        if (taskDto.Project != null && taskDto.Project.ProjectID != null)
                        {
                            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectID == taskDto.Project.ProjectID);
                            if (project != null)
                            {
                                taskDto.Project = _mapper.Map<ProjectDTO>(project);
                            }
                            else
                            {
                         
                                taskDto.Project = new ProjectDTO { /* Default values or null depending on your logic */ };
                               
                            }
                        }
                    }

                    userTaskDTOs.Add(userTaskDTO);
                }

                response.Data = userTaskDTOs;
                response.IsSucess = true;
                response.Message = "Tasks for all users retrieved successfully";
            }
            catch (Exception ex)
            {
                // Handle exceptions and set error response if needed
                response.IsSucess = false;
                response.Message = $"Error: {ex.Message}";
                // Log the exception or perform error handling as per your application's requirements
            }

            return response;
        }
        public async Task<ServiceResponse<List<UserTaskDTO>>> GetUserTasksWithProjects(int UserID)
        {
            var response = new ServiceResponse<List<UserTaskDTO>>();

            try
            {
                var userss = await _context.AppUsers.ToListAsync();
                var users = await _context.AppUsers.Where(e=> e.UserID == UserID).ToListAsync(); // Fetch all users asynchronously

                var userTaskDTOs = new List<UserTaskDTO>();

                foreach (var user in users)
                {
                    var userTasks = await _context.Tasks
                        .Include(t => t.Project)
                        
                        .Where(t => t.UserID == user.UserID)
                        .ToListAsync(); // Fetch all tasks for the user asynchronously

                    var userTaskDTO = _mapper.Map<UserTaskDTO>(user);
                    userTaskDTO.Tasks = _mapper.Map<ICollection<TaskDTO>>(userTasks);

                    foreach (var taskDto in userTaskDTO.Tasks)
                    {
                        if (taskDto.Project != null && taskDto.Project.ProjectID != null)
                        {
                            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectID == taskDto.Project.ProjectID);
                            if (project != null)
                            {
                                taskDto.Project = _mapper.Map<ProjectDTO>(project);
                            }
                            else
                            {

                                taskDto.Project = new ProjectDTO { /* Default values or null depending on your logic */ };

                            }
                        }
                    }

                    userTaskDTOs.Add(userTaskDTO);
                }

                response.Data = userTaskDTOs;
                response.IsSucess = true;
                response.Message = "Tasks for all users retrieved successfully";
            }
            catch (Exception ex)
            {
                // Handle exceptions and set error response if needed
                response.IsSucess = false;
                response.Message = $"Error: {ex.Message}";
                // Log the exception or perform error handling as per your application's requirements
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetUsers()
        {
            var response = new ServiceResponse<List<GetUserDTO>>();

            var appUsers = await _context.AppUsers
                .Include(u => u.Role)
                .Include(u => u.UserProjects)
                .ThenInclude(up => up.Project)
                .ToListAsync();

            var userDTOs = _mapper.Map<List<GetUserDTO>>(appUsers);

            response.Data = userDTOs;
            response.IsSucess = true;
            response.Message = "True";

            return response;
        }

    }
}
