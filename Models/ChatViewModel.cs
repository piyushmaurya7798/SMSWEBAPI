namespace SMSWEBAPI.Models
{
    public class ChatViewModel
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
        public List<Chat> Messages { get; set; }

    }
}
