using System.Text.Json.Serialization;

namespace Chat.Models.Command
{
    public class UserCommand
    {
        [JsonPropertyName("full_name")]
        public required string Fullname {  get; set; }
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        [JsonPropertyName("password")]
        public required string Password { get; set; }

    }
}
