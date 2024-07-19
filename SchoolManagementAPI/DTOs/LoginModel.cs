using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.DTOs
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
