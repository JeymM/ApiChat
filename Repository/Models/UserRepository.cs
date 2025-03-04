using Chat.Models.Command;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Chat.Repository.Models
{
    public class UserRepository
    {
        public async Task<bool> CreatedAsync(UserCommand userCommand)
        {
            string sql = "INSERT INTO Users(Fullname,Email,Password) VALUES(@Fullname,@Email,@Password)";
            using(var connection =new SqlConnection("Data Source=PCJEYM\\SQLEXPRESS;Initial Catalog=CHATWEB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                connection.Open();
                UserDatabaseModel userDatabaseModel = new UserDatabaseModel
                {
                    Fullname=userCommand.Fullname,
                    Email=userCommand.Email,
                    Password=userCommand.Password,
                };
                int rowAffected=await connection.ExecuteAsync(sql, userDatabaseModel);
                return rowAffected > 0;
            }
        }
    }
}
