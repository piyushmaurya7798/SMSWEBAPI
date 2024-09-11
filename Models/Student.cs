using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class Student
    {
        [Key]
        public int userid { get; set; }
        public string? username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime DOB { get; set; }
        public string? gender { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? EnrollDate { get; set; }
        public string? ClassId { get; set; }
        public double Fees { get; set; }


    }
}
