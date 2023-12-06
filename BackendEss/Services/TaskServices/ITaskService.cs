using BackendEss.Dtos.Tasks;
using BackendEss.Model;

namespace BackendEss.Services.TaskServices
{
    public interface ITaskService
    {
        Task<ServiceResponse<int>> CreateTask(AddTaskDTO Task);
    }
}
