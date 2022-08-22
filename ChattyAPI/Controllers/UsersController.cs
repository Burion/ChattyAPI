using AutoMapper;
using ChattyAPI.Models;
using ChattyServices.Dtos;
using ChattyServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChattyAPI.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<GetUsersResponse> Search([FromQuery] string searchQuery)
        {
            try
            {
                var users = await _usersService.SearchUsersByLogin(searchQuery);

                return new GetUsersResponse()
                {
                    Message = "Success",
                    Data = users
                };
            }
            catch
            {
                return new GetUsersResponse()
                {
                    Message = "Error"
                };
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<GetUserResponse> Get([FromRoute] string userId)
        {
            try
            {
                var user = await _usersService.GetUserByLogin(userId);

                return new GetUserResponse()
                {
                    Message = "Success",
                    Data = user
                };
            }
            catch
            {
                return new GetUserResponse()
                {
                    Message = "Error"
                };
            }
        }

        [HttpPatch]
        public async Task<GetUserResponse> Patch([FromBody] UpdateUserModel model)
        {
            try
            {
                if (model.Login != User.Identity.Name)
                    throw new System.Web.Http.HttpResponseException(HttpStatusCode.Unauthorized);

                if (!string.IsNullOrEmpty(model.OldPassword))
                {
                    if (!await _usersService.VerifyPassword(model.Login, model.OldPassword))
                    { 
                        return new GetUserResponse()
                        {
                            Message = "Invalide password"
                        };
                    }

                    await _usersService.ChangePassword(model.Login, model.NewPassword);
                };

                var updatedUser = await _usersService.UpdateUser(_mapper.Map<UserDto>(model));

                return new GetUserResponse()
                {
                    Message = "Success",
                    Data = updatedUser
                };
            }
            catch
            {
                return new GetUserResponse()
                {
                    Message = "Error"
                };
            }
        }
    }
}
