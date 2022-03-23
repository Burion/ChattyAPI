using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChattyServices.Interfaces;
using ChattyServices.Services;
using Microsoft.AspNetCore.Authorization;

namespace ChattyAPI.Controllers
{
    [Route("api/v2/chats")]
    [ApiController]
    public class ChatsV2Controller : ControllerBase
    {
        public ChatsV2Controller()
        {

        }

        [Authorize]
        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            var chatsService = new ChatsService();

            return new JsonResult(chatsService.GetChatsForUser(userId));
        }
    }
}
