using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Application
    {
        [Key]
        public int applicationId { get; set; }
        public string? Email {  get; set; } 
        public string? Phone {  get; set; } 
        public string? HighestQualification {  get; set; } 
        public string? Grade {  get; set; }
        public string? LatestRecords { get; set; }
        public string? ApplyingFor { get; set; }

        public DateTime Date { get; set; }
    }
}
