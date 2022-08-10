using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.DTO
{
    public class ProjectDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Name { get; set; } = String.Empty;

        [Required]
        public string Password { get; set; } = String.Empty;
    }
}

