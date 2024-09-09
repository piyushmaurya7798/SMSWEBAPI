using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class TeacherAttendance
    {
        [Key]
        public int TeacherAttendanceId { get; set; }
        public int TeacherId { get; set; }
        public bool Status { get; set; }
    }
}
