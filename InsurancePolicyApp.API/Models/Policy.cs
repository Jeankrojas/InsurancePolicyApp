using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsurancePolicyApp.API.Models
{
    public class Policy
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Description { get; set; }

        [Required]
        public int CoveragePeriod { get; set; }

        [Required]
        public double Price { get; set; }

        public ICollection<PolicyEventType> PolicyEventTypes { get; set; }

        public ICollection<PolicyClient> PolicyClients { get; set; }

    }
}