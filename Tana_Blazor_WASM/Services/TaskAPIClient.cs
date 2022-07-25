using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ViewModels;

namespace Tana_Blazor_WASM.Services
{
    public class TaskAPIClient : ITaskAPIClient
    {

        public HttpClient _httpClient { get; set; }
        public TaskAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public TaskAPIClient()
        {


        }

        public async Task<List<TaskDTO>> Getlist(TaskListSearch taskListSearch)
        {
            string url = $"/api/tasks?name={taskListSearch.Name}&assignid={taskListSearch.AssigneeId}&Priority={taskListSearch.Priority}";
            var result = await _httpClient.GetFromJsonAsync<List<TaskDTO>>(url);

            return result;
        }

        public async Task<List<TaskDTO>> GetTaskById(string id)
        {

            var result = await _httpClient.GetFromJsonAsync<List<TaskDTO>>("api/tasks");
            var final = result.Where(c => c.Id == System.Guid.Parse(id)).ToList();
            return final;
        }

        public async Task<bool> CreateTask(TaskCreateRequest taskCreateRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/tasks", taskCreateRequest);
            return result.IsSuccessStatusCode;
        }
    }
}
