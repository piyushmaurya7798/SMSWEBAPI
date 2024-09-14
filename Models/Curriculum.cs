using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class Curriculum
    {
        [Key]
        public int CurriculumId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? Syllabus { get; set; }

    }
}
