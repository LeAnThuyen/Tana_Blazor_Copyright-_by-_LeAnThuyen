using API_Blazor.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class TaskCreateRequest
    {


        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(20, ErrorMessage = "Please fill your name")]
        [Required]
        public string Name { get; set; }
        [Required]
        public Priority? Priority { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
