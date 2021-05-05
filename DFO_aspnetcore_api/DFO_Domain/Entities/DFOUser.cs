using System.ComponentModel.DataAnnotations;
using DFO_Domain.Common;

namespace DFO_Domain.Entities
{
    public class DFOUser: AuditableBaseEntity
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