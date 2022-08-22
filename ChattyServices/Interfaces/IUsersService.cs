using ChattyDAL.Models;
using ChattyServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Interfaces
{
    public interface IUsersService
    {
        Task<UserDto> GetUserByLogin(string login);
        Task<IEnumerable<UserDto>> SearchUsersByLogin(string query);
        Task<bool> VerifyPassword(string login, string password);
        Task<UserDto> CreateUser(UserDto user);
        Task<UserDto> RegisterUser(UserWithPasswordDto user);
        Task<UserDto> UpdateUser(UserDto user);
        Task<string> ChangePassword(string userId, string password);
    }
}
