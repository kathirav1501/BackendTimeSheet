using AutoMapper;
using BackendEss.DBContext;
using BackendEss.Dtos.Project;
using BackendEss.Dtos.User;
using BackendEss.Model;
using Microsoft.EntityFrameworkCore;

namespace BackendEss.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        private readonly EssDBContext _context;
        private readonly IMapper _mapper;
        public ProjectService(EssDBContext essDBContext, IMapper mapper)
        {
            _context = essDBContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<ProjectDTO>>> GetProjectList()
        {
            var response = new ServiceResponse<List<ProjectDTO>>();
            var ProjectList = await _context.Projects.ToListAsync();

            var projectDTO = _mapper.Map<List<ProjectDTO>>(ProjectList);
            response.Data = projectDTO;
            response.Message = "projects list";
            response.IsSucess = true;

            return response;

        }
    }
}
