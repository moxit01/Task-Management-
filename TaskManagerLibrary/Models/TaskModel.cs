using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerLibrary.Models
{
    public class TaskModel : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Task Name")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Date)]
        [EmailAddress]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; } = String.Empty;

        [Required]
        public EmployeeModel User { get; set; } = new EmployeeModel();

        [Required]
        public ProjectModel Project { get; set; } = new ProjectModel();
    }
}

