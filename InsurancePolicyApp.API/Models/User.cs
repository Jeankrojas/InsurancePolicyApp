using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsurancePolicyApp.API.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]        
        public byte[] PasswordSalt { get; set; }
    }
}