using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class Performance
    {
        [Key]
        public int PerformanceId { get; set; }

        public int StudentId { get; set; }
        public double? Grade { get; set; }

        public DateTime Date { get; set; }
    }
}
