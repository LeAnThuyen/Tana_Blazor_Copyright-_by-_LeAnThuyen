using API_Blazor.Entities;
using System;

namespace ViewModels
{
    public class TaskDTO
    {


        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? AssigneeId { get; set; }
        public string AssigneeName { get; set; }
        public DateTime Created { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
