using BackendEss.Dtos.Tasks;
using BackendEss.Dtos.User;
using BackendEss.Model;
using BackendEss.Services.TaskServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendEss.Controllers
{
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("addTask")]
        public async Task<ActionResult<ServiceResponse<int>>> AddTask([FromBody] AddTaskDTO request)
        {
            var response = await _taskService.CreateTask(request);
            if (!response.IsSucess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
