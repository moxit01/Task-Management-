using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskManagerAPI.Models
{
    [Table("Employees")]
    public class Employee: IdentityUser
    {
        [Key]
        public int EmployeeId { get; set; } 
        public string FullName { get; set; } = String.Empty;
        public string EmailAddress { get; set; } = String.Empty;
    }
}

