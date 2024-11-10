using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class TaskToDo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Description { get; set; } = null;

        public bool Done { get; set; }
    }
}
