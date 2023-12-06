using BackendEss.Dtos.Project;
using BackendEss.Dtos.Tasks;
using BackendEss.Model;

namespace BackendEss.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<ServiceResponse<List<ProjectDTO>>> GetProjectList();
    }
}
