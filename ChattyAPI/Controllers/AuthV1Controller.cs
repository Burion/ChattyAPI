using ChattyServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ChattyServices.Dtos;
using ChattyServices.ServiceErrors;
using ChattyServices.Interfaces;
using AutoMapper;
using ChattyAPI.Models;
using ChappyAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChattyAPI.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthV1Controller : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public AuthV1Controller(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<JwtResponse> Post([FromBody] UserLoginModel userModel)
        {
            try
            {
                if (await _usersService.VerifyPassword(userModel.Login, userModel.Password))
                {
                    var tokenInfo = await GenerateToken(userModel.Login);
                
                    return tokenInfo; 
                }

                return new JwtResponse()
                {
                    Message = "Invalid credentials"
                };
            }
            catch
            {
                return new JwtResponse()
                {
                    Message = "Error"
                };
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<UserDto> Post([FromBody] UserRegisterModel userToRegister)
        {
            try
            {
                var user = await _usersService.RegisterUser(_mapper.Map<UserWithPasswordDto>(userToRegister));

                return user;
            }
            catch(ItemAlreadyExistException ex)
            {
                throw;   
            }
        }

        private async Task<JwtResponse> GenerateToken(string login)
        {
            var user = await _usersService.GetUserByLogin(login);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(2)).ToUnixTimeSeconds().ToString())
            };

            var jwtHeader = new JwtHeader(
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THISISMYKEYTHISISMYKEY")),
                    SecurityAlgorithms.HmacSha256)
                );
            var jwtPayload = new JwtPayload(claims);
            var token = new JwtSecurityToken(jwtHeader, jwtPayload);

            var output = new JwtResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.Login, 
                Message = "Success"
            };

            return output;
        }
    }
}
