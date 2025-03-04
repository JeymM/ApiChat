namespace Chat.Repository.Models
{
    public class MessageDatabaseModel
    {
        public long  Id {  get; set; }
        public int UserSenderId {  get; set; }
        public int UserRecipientId {  get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
