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
    public class UserController : ControllerBase
    {
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserCommand userCommand)
        {
            UserService userService = new UserService();    
            UserResponse userResponse =await userService.CreatedUsersAsync(userCommand);
            return StatusCode(HttpStatusCode.Created.GetHashCode(),userResponse);
        }
    }
}