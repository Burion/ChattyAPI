using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChattyServices.Interfaces;
using ChattyServices.Services;
using ChattyServices.Dtos;

namespace ChattyAPI.Controllers
{
    [Route("api/v1/chats")]
    [ApiController]
    public class ChatsV1Controller : ControllerBase
    {
        private readonly IChatsService _chatsService;

        public ChatsV1Controller(IChatsService chatsService)
        {
            _chatsService = chatsService;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<ChatDto>> Get(string userId)
        {
            var chats = await _chatsService.GetChatsForUser(userId);

            return chats;
        }
    }
}
