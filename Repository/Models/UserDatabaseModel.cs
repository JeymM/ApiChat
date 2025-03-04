namespace Chat.Repository.Models
{
    public class UserDatabaseModel
    {
        public   long Id { get; set; }
        public  string Fullname { get; set; }
        public  string Email { get; set; }
        public  string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set;}
    }
}
