using BackendEss.Dtos.Project;
using BackendEss.Dtos.User;
using BackendEss.Model;
using BackendEss.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace BackendEss.Controllers
{
    public class ProjectController : ControllerBase 
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
           _projectService = projectService;
        }

        [HttpPost("GetAllProjects")]
        public async Task<ActionResult<ServiceResponse<List<ProjectDTO>>>> GetProjectList()
        {
            var response = await _projectService.GetProjectList();
            if (!response.IsSucess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
