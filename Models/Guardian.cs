using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class Guardian
    {
        [Key]
        public int Id { get; set; }
        public string GuardianId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
