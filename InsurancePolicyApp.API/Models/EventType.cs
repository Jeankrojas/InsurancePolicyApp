using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsurancePolicyApp.API.Models
{
    public class EventType
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        public ICollection<PolicyEventType> PolicyEventTypes { get; set; }
    }
}