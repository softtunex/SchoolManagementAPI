using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.DTOs
{
    public class StudentDTO
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string ParentContact { get; set; }

        [Required]
        [StringLength(10)]
        public string Level { get; set; }
    }
}
