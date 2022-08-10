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
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; } = String.Empty;

        [Required]
        public string FullName { get; set; } = String.Empty;
    }
}

