using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;
using Task = API_Blazor.Entities.Task;

namespace API_Blazor.Respositories
{
    public interface ITaskRepositoty
    {
        Task<IEnumerable<Entities.Task>> GetTaskList(TaskListSearch taskListSearch);
        Task<Task> CreateTask(Task task);
        Task<Task> UpdateTask(Task task);
        Task<string> DeleteTask(Task task);
        Task<Task> GetById(Guid id);
    }
}
