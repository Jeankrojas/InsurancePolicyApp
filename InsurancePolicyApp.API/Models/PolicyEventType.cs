using System.ComponentModel.DataAnnotations;

namespace InsurancePolicyApp.API.Models
{
    public class PolicyEventType
    {
        public int Id { get; set; }

        [Required]
        public double Percent { get; set; }
        [Required]
        public int RiskTypeId { get; set; }
        public RiskType RiskType { get; set; }

        [Required]
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }
        
        [Required]
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
    }
}