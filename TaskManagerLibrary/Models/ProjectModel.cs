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
        [Display(Name = "Poject Description")]
        public string Desc { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public string EndDate { get; set; } = string.Empty;

        [Required]
        public EmployeeModel[] Users { get; set; } = new EmployeeModel[10];
    }
}
