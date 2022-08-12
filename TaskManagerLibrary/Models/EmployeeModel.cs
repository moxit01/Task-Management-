using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerLibrary.Models
{
    public class EmployeeModel: IdentityUser
    {
        public string EmployeeId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public ProjectModel[] projects { get; set; }

    }
}

