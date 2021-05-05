using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DFO_Infrastructure.Identity.Models
{
    public class ApplicationUser: IdentityUser<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
    }
}