using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class StudentAttendance
    {
        [Key]
        public int studentAttenId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public bool Status { get; set; }
    }
}
