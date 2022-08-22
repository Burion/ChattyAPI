using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChattyServices.Interfaces;
using ChattyServices.Services;
using ChattyServices.Dtos;
using ChattyAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace ChattyAPI.Controllers
{
    [Route("api/v1/chats")]
    [ApiController]
    public class ChatsV1Controller : ControllerBase
    {
        private readonly IChatsService _chatsService;
        private readonly IUsersService _usersService;

        public ChatsV1Controller(IChatsService chatsService, IUsersService usersService)
        {
            _chatsService = chatsService;
            _usersService = usersService;
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<GetChatsResponse> Get([FromRoute] string userId)
        {
            var chats = await _chatsService.GetChatsForUser(userId);

            return new GetChatsResponse()
            {
                Message = "Success",
                Data = chats
            };
        }

        [HttpGet]
        public async Task<GetChatsResponse> SearchChats([FromQuery] [Required] string searchQuery)
        {
            try
            {
                var users = await _usersService.SearchUsersByLogin(searchQuery);

                var chats = users.Select(u => new ChatDto()
                {
                    Name = u.DisplayedName,
                    UserLogin = u.Login
                });

                return new GetChatsResponse()
                {
                    Message = "Success",
                    Data = chats
                };
            }
            catch
            {
                return new GetChatsResponse()
                {
                    Message = "Error"
                };
            }
        }
    }
}
