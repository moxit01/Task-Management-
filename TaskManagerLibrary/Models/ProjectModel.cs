using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerLibrary.Models
{
    public class ProjectModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ProjectId { get; set; }

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
