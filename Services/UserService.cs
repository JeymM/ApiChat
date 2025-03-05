using Chat.Models.Command;
using Chat.Models.ViewModels;
using Chat.Repository.Models;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Chat.Services
{
    public class UserService
    {
        public async Task<UserResponse>CreatedUsersAsync(UserCommand userCommand)
        {
           
            bool hasEmptyFields =
                IsNullOrEmpty(userCommand.Fullname) ||
                IsNullOrEmpty(userCommand.Email) ||
                IsNullOrEmpty(userCommand.Password); // 
            userCommand.Password = BCrypt.Net.BCrypt.HashPassword(userCommand.Password);

            bool IsValidEmail = Regex.Match(userCommand.Email, "^[a-z0-9]+[@]{1}[a-z0-9.]+$").Success;

            //validaciones
            if(IsValidEmail is false ) 
            {
                throw new Exception("Hay criterios que no cumple el email");
            }
            if(hasEmptyFields)
            {
                throw new Exception("Hay campos sin diligenciar");
            }
            UserRepository userRepository = new UserRepository();
            bool IscreatedUser=await userRepository.CreatedAsync(userCommand);

            if(IscreatedUser is false)
            {
                throw new Exception("El usuario no se ha creado con exito");
            }
            return new UserResponse
            {
                AccessToken = " ",
                ExpireAt = " "
            };
        }
        public bool IsNullOrEmpty(string text)
        {
            return text == null || text.Trim().Length == 0;
        }
    }
}
