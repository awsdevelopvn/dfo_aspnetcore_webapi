using System;
using System.ComponentModel.DataAnnotations;

namespace DFO_Domain.Common
{
    public class AuditableBaseEntity
    {
        [Required]
        public virtual int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}