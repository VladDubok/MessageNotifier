namespace MessageService.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string From { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string To { get; set; } = null!;
        
        /*
            Email = 1
        */
        public int MessageType { get; set; }
    }
}