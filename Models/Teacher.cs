namespace SMSWEBAPI.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? username { get; set; }
        public string? Qualification { get; set; }
        public string? SubjectName { get; set; }
        public double Salary { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime HireDate { get; set; }
    }
}
