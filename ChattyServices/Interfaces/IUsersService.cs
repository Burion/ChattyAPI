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
        UserDto GetUserByLogin(string login);
        bool VerifyPassword(string login, string password);
        UserDto CreateUser(UserDto user);
        UserDto RegisterUser(UserRegisterModel user);
    }
}
