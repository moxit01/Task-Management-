using System.ComponentModel.DataAnnotations;

namespace TaskManagerLibrary.Models
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today;

        [Required]
        public EmployeeModel[] Users { get; set; } = new EmployeeModel[10];
    }
}
