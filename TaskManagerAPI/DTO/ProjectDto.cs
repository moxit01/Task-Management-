using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.DTO
{
    public class ProjectDto
    {
        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        public string Desc { get; set; } = String.Empty;

        [Required]
        public string StartDate { get; set; } = String.Empty;

        [Required]
        public string EndDate { get; set; } = String.Empty;

        [Required]
        public string[] Users { get; set; }
    }
}

