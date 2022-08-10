using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerLibrary.Models
{
    public class ProjectModel : IdentityUser
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Date)]
        [EmailAddress]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        [EmailAddress]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;

        [Required]
        public EmployeeModel[] User { get; set; } = new EmployeeModel[10];
    }
}

