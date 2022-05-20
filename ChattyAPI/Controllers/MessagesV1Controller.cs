using ChattyServices.Dtos;
using ChattyServices.Interfaces;
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
        private readonly IMessagesService _messagesService;

        public MessagesV1Controller(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        //[HttpGet("{firstUserLogin}/{secondUserLogin}")]
        public async Task<IEnumerable<MessageDto>> Get([FromQuery] string firstUserId, [FromQuery] string secondUserId)
        {
            var messages = await _messagesService.GetMessagesForUsers(firstUserId, secondUserId);

            return messages;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MessageDto message)
        {
            var upsertedMessage = await _messagesService.UpsertMessage(message);

            return new JsonResult(upsertedMessage);
        }
    }
}
