using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tana_Blazor_WASM.Services;
using ViewModels;

namespace Tana_Blazor_WASM.Pages
{
    public partial class ToDoList
    {
        [Inject] private ITaskAPIClient taskAPIClient { get; set; }
        [Inject] private IUserClient userClient { get; set; }
        private List<TaskDTO> _lstdto;
        private TaskListSearch _taskListSearch;
        private List<AssigneeDTO> _lstAssignee;
        public ToDoList()
        {
            _taskListSearch = new TaskListSearch();
            _lstAssignee = new List<AssigneeDTO>();
            _lstdto = new List<TaskDTO>();
        }
        protected override async Task OnInitializedAsync()
        {
            _lstdto = await taskAPIClient.Getlist(_taskListSearch);
            _lstAssignee = await userClient.GetListDTO();
        }


        private async Task FormSubmitted(EditContext editContext)
        {

            _lstdto = await taskAPIClient.Getlist(_taskListSearch);
            var x = 1;

        }




    }


}
