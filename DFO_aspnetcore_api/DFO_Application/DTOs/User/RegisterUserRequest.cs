using System.ComponentModel.DataAnnotations;

namespace DFO_Application.DTOs.User
{
    public class RegisterUserRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int? Age { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
    }
}