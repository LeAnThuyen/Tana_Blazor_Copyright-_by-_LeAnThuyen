using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Blazor.Entities
{
    public class Task
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? AssigneeId { get; set; }
        [ForeignKey("AssigneeId")]
        public User Assignee { get; set; }
        public DateTime Created { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

    }
}
