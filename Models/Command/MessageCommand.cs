using System.Text.Json.Serialization;

namespace Chat.Models.Command
{
    public class MessageCommand
    {
        [JsonPropertyName("sender_id")]
        public required int SenderId {  get; set; }
        [JsonPropertyName("recipient_id")]
        public required int RecipientId {  get; set; }
        [JsonPropertyName("message")]
        public required string Message {  get; set; }
    }
}
