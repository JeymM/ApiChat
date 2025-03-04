using Chat.Models.Command;
using Chat.Models.ViewModels;
using Chat.Repository.Models;

namespace Chat.Services
{
    public class MessageService
    {
        public async Task<MessageResponse> CreatedMessageAsync(MessageCommand messageCommand)
        {
            bool hasEmptyField=IsNullOrEmpty(messageCommand.Message);
            if(hasEmptyField)
            {
                throw new Exception("Hay campos sin diligenciar");
            }
            MessageRepository messageRepository = new MessageRepository();
            bool IsCreatedMessage=await messageRepository.CreatedMessageAsync(messageCommand);
            if(IsCreatedMessage is false ) {
                throw new Exception("Ha ocurrido un error para crear el mensaje");
            }
            return new MessageResponse
            {
                IsCreated = true
            };
        }
        public bool IsNullOrEmpty(string text)
        {
            return text == null || text.Trim().Length == 0;
        }
    }
}