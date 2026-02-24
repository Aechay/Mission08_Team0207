using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0207.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        public string TaskName { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required.")]
        [Range(1, 4, ErrorMessage = "Quadrant must be 1, 2, 3, or 4.")]
        public int Quadrant { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool Completed { get; set; } = false;
    }
}
