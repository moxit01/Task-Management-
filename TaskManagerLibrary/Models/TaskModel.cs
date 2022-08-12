using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerLibrary.Models
{
    public class TaskModel: IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int TaskId { get; set; }

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
        public EmployeeModel User { get; set; }

        [Required]
        public ProjectModel Project { get; set; }
    }
}

