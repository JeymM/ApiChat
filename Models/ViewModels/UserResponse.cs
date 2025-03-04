namespace Chat.Models.ViewModels
{
    public class UserResponse
    {
        public required string AccessToken { get; set; }
        public required string ExpireAt { get; set; }
    }
}
