using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class Fees
    {
        [Key]
        public int FeesId { get; set; }

        public int ClassId { get; set; }

        public double FeesValue { get; set;}
    }
}
