using System.ComponentModel.DataAnnotations;

namespace TaskManagerLibrary.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Task Name")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public string EndDate { get; set; } = String.Empty;

        [Required]
        public EmployeeModel User { get; set; } = new EmployeeModel();

        [Required]
        public ProjectModel Project { get; set; } = new ProjectModel();
    }
}

