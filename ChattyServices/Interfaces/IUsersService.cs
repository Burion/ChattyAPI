using ChattyDAL.Models;
using ChattyServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Interfaces
{
    interface IUsersService
    {
        Task<UserDto> GetUserByLogin(string login);
        Task<bool> VerifyPassword(string login, string password);
        Task<UserDto> CreateUser(UserDto user);
        Task<UserDto> RegisterUser(UserRegisterModel user);
    }
}
