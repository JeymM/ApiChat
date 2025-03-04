using Chat.Models.Command;
using Chat.Models.ViewModels;
using Chat.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Chat.Controllers
{
    [Controller]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ChatController:ControllerBase
    {
        [HttpPost("save-message")]
        public async Task<IActionResult> SaveMessageAsync([FromBody] MessageCommand messageCommand)
        {
            MessageService chatService = new MessageService();
            MessageResponse chatViewModel=await chatService.CreatedMessageAsync(messageCommand);
            return StatusCode(HttpStatusCode.Created.GetHashCode(), chatViewModel);
        }
    }
}
