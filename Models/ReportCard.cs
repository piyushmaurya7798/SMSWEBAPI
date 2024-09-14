using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class ReportCard
    {
        [Key]
        public int ReportCardId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public double? OverallGrade { get; set; }
    }
}
