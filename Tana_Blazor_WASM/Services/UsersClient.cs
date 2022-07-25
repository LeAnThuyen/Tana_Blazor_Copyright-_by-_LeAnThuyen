using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ViewModels;

namespace Tana_Blazor_WASM.Services
{
    public class UsersClient : IUserClient
    {
        public HttpClient _HttpClient;
        public UsersClient(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<List<AssigneeDTO>> GetListDTO()
        {
            return await _HttpClient.GetFromJsonAsync<List<AssigneeDTO>>("api/users");
        }
    }
}
