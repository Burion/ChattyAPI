using ChattyServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattyAPI.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesV1Controller : ControllerBase
    {
        //[HttpGet("{firstUserLogin}/{secondUserLogin}")]
        public IActionResult Get([FromQuery] string firstUserId, [FromQuery] string secondUserId)
        {
            var messagesService = new MessagesService();
            var messagesDtos = messagesService.GetMessagesForUsers(firstUserId, secondUserId);

            return new JsonResult(messagesDtos);
        }
    }
}
