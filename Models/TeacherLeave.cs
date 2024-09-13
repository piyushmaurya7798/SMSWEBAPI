using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class TeacherLeave
    {
            [Key]
            public int Id { get; set; }
            public string? TeacherId { get; set; }
            public string? Leavetype { get; set; }
            public DateOnly StartDate { get; set; }
            public DateOnly EndDate { get; set; }
            public string? LeaveReason { get; set; }
            public string? Status { get; set; }

        }
    
}

