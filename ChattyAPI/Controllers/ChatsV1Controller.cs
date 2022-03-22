using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChattyServices.Interfaces;
using ChattyServices.Services;

namespace ChattyAPI.Controllers
{
    [Route("api/v1/chats")]
    [ApiController]
    public class ChatsV1Controller : ControllerBase
    {
        public ChatsV1Controller()
        {

        }

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            var chatsService = new ChatsService();

            return new JsonResult(chatsService.GetChatsForUser("Vlad"));
        }
    }
}
