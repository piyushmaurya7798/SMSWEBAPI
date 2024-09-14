using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public int ClassId { get; set; }
    }
}
