using BackendEss.Dtos.Tasks;
using BackendEss.Dtos.User;
using BackendEss.Model;
using BackendEss.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BackendEss.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService ;
        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }
        [HttpPost("GetAllUsers")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDTO>>>> GetAllUsers()
        {
            var response = await _userService.GetUsers();
            if (!response.IsSucess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("GetAllUsersTasks")]
        public async Task<IActionResult> GetAllUsersTasksWithProjects()
        {
            try
            {
                var response = await _userService.GetAllUsersTasksWithProjects();

                if (!response.IsSucess)
                {
                    return StatusCode(500, response); // Or return appropriate error status code
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<List<UserTaskDTO>>
                {
                    IsSucess = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = null
                });
            }
        }

        [HttpGet("GetSingleUsersTasks")]
        public async Task<IActionResult> GetSingleUsersTasksWithProjects(int UserID)
        {
            try
            {
                var response = await _userService.GetUserTasksWithProjects(UserID);

                if (!response.IsSucess)
                {
                    return StatusCode(500, response); // Or return appropriate error status code
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServiceResponse<List<UserTaskDTO>>
                {
                    IsSucess = false,
                    Message = $"An error occurred: {ex.Message}",
                    Data = null
                });
            }
        }
    }
}
