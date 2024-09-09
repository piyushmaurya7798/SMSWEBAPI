using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        public int ClassId { get; set; }
        public string? Attachment { get; set; }
    }
}
