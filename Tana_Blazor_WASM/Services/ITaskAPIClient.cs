using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace Tana_Blazor_WASM.Services
{
    public interface ITaskAPIClient
    {
        Task<List<TaskDTO>> Getlist(TaskListSearch taskListSearch);
        Task<List<TaskDTO>> GetTaskById(string id);
        Task<bool> CreateTask(TaskCreateRequest taskCreateRequest);


    }
}
