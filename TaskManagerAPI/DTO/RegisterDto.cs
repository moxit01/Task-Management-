using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.DTO
{
    public class RegisterDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = String.Empty;

        [Required]
        [StringLength(255, ErrorMessage = "Must be of minimum 5 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;

        [Required]
        public string FullName { get; set; } = String.Empty;
    }
}

