using System.ComponentModel.DataAnnotations;

namespace SMSWEBAPI.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
