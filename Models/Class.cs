using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        public string? ClassName { get; set; }
        public int TimeTableId { get; set; }
        public int TeacherId { get; set; }
    }
}
