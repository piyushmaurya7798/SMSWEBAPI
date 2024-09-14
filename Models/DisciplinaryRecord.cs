using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class DisciplinaryRecord
    {
        [Key]
        public int DisciplinaryRecordId { get; set; }

        public int StudentId { get; set; }

        public string? Action { get; set; }

        public DateTime Date { get; set; }
    }
}
