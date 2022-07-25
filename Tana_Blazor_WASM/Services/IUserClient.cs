using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace Tana_Blazor_WASM.Services
{
    public interface IUserClient
    {

        Task<List<AssigneeDTO>> GetListDTO();

    }
}
