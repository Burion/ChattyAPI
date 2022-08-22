using AutoMapper;
using ChattyAPI.Models;
using ChattyServices.Dtos;
using ChattyServices.Interfaces;
using ChattyServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattyAPI.Controllers
{
    [Route("api/v1/messages")]
    [ApiController]
    public class MessagesV1Controller : ControllerBase
    {
        private readonly IMessagesService _messagesService;
        private readonly IMapper _mapper;

        public MessagesV1Controller(IMessagesService messagesService, IMapper mapper)
        {
            _messagesService = messagesService;
            _mapper = mapper;
        }

        [HttpGet("{firstUserLogin}/{secondUserLogin}")]
        public async Task<IEnumerable<MessageDto>> Get([FromQuery] string firstUserId, [FromQuery] string secondUserId)
        {
            var messages = await _messagesService.GetMessagesForUsers(firstUserId, secondUserId);

            return messages;
        }

        /// <summary>
        /// Get messages from conversation between current user and and given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("{userId}")]
        public async Task<GetMessagesResponse> Get(string userId)
        {
            try
            {
                var messages = await _messagesService.GetMessagesForUsers(User.Identity.Name, userId);

                return new GetMessagesResponse()
                {
                    Message = "Success",
                    Data = messages
                };
            }
            catch
            {
                return new GetMessagesResponse()
                {
                    Message = "Error"
                };
            }
        }

        /// <summary>
        /// Post method for creating message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<PostMessageResponse> Post([FromBody] PostMessageModel message)
        {
            try
            {
                var messageToSend = _mapper.Map<MessageDto>(message);
                messageToSend.AuthorId = User.Identity.Name;

                var upsertedMessage = await _messagesService.UpsertMessage(messageToSend);

                var response = new PostMessageResponse()
                {
                    Message = "Success",
                    Data = upsertedMessage
                };

                return response;
            }
            catch(Exception)
            {
                var response = new PostMessageResponse()
                {
                    Message = "Error"
                };

                return response;
            }
        }
    }
}
