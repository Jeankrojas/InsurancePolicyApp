using System.ComponentModel.DataAnnotations;

namespace InsurancePolicyApp.API.Models
{
    public class PolicyClient
    {
        public int Id { get; set; }

        [Required]
        public System.DateTime ValidityStarted { get; set; }

        [Required]
        public int PolicyId { get; set; }
        public Policy Policy { get; set; }
        
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}