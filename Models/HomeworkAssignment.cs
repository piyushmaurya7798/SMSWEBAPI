using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class HomeworkAssignment
    {
        [Key]
        public int HomeworkAssignmentId { get; set; }
        public int ClassId { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }
    }
}
