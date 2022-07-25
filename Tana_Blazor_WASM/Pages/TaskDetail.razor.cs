using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tana_Blazor_WASM.Services;
using ViewModels;

namespace Tana_Blazor_WASM.Pages
{
    public partial class TaskDetail
    {
        [Inject] ITaskAPIClient taskAPIClient { get; set; }
        private List<TaskDTO> _lstdto;
        public TaskDetail()
        {

            _lstdto = new List<TaskDTO>();
        }
        protected override async Task OnInitializedAsync()
        {
            _lstdto = await taskAPIClient.GetTaskById(TaskId);
        }

    }
}
