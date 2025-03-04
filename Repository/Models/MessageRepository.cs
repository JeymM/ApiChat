
using Chat.Models.Command;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Chat.Repository.Models
{
    public class MessageRepository
    {
        public async Task<bool>CreatedMessageAsync(MessageCommand messageCommand)
        {
            string sql = "INSERT INTO Message(UserSenderId,UserRecipientId,Message) VALUES(@UserSenderId,@UserRecipientId,@Message)";
            using (var connection = new SqlConnection("Data Source=PCJEYM\\SQLEXPRESS;Initial Catalog=CHATWEB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                connection.Open();
                MessageDatabaseModel messageDatabaseModel = new MessageDatabaseModel
                {
                    UserSenderId = messageCommand.SenderId,
                    UserRecipientId = messageCommand.RecipientId,
                    Message = messageCommand.Message
                };
                int rowsAffected=await connection.ExecuteAsync(sql, messageDatabaseModel);
                return rowsAffected > 0;
            }
        }
     }
       
}
