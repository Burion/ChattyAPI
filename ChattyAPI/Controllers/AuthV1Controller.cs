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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChattyAPI.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthV1Controller : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Post ([FromBody] UserLoginModel userModel)
        {
            //TOTO DI
            var usersService = new UsersService();

            if (usersService.VerifyPassword(userModel.Login, userModel.Password))
            {
                var tokenInfo = GenerateToken(userModel.Login);
                return new JsonResult(tokenInfo); 
            }

            return BadRequest("Invalid credentials");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Post([FromBody] UserRegisterModel userToRegister)
        {
            //TODO DI 
            var usersService = new UsersService();

            try
            {
                var user = usersService.RegisterUser(userToRegister);

                return new JsonResult(user);
            }
            catch(ItemAlreadyExistException ex)
            {
                return BadRequest("This user already exists");
            }
        }

        private dynamic GenerateToken(string login)
        {
            var usersService = new UsersService();
            var user = usersService.GetUserByLogin(login);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.GivenName, user.DisplayedName),
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

            var output = new
            {
                Acess_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.Login
            };

            return output;
        }
    }
}
