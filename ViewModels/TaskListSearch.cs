using API_Blazor.Entities;
using System;

namespace ViewModels
{
    public class TaskListSearch
    {
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }
        public Priority? Priority { get; set; }
    }
}
