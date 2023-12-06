
using AutoMapper;
using BackendEss.DBContext;
using BackendEss.Dtos.Tasks;
using BackendEss.Model;

namespace BackendEss.Services.TaskServices
{
    public class TaskService : ITaskService
    {
        private readonly EssDBContext _context;
        private readonly IMapper _mapper;

        public TaskService(IMapper mapper ,EssDBContext essDBContext )
        {
            _context = essDBContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<int>> CreateTask(AddTaskDTO Task)
        {
                var response = new ServiceResponse<int>();
            
            var tasks = _mapper.Map<Tasks>( Task );
            _context.Tasks.Add(tasks);
            var result = await _context.SaveChangesAsync();

            response.Data = result;
            response.IsSucess = true;
            response.Message = "created";

            return response;

        }
    }
}
