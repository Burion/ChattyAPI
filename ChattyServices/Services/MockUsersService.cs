using ChattyServices.Dtos;
using ChattyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Services
{
    public class MockUsersService : IUsersService
    {
        public Task<string> ChangePassword(string userId, string password)
        {
            throw new NotImplementedException();
        }

        public UserDto CreateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserByLogin(string login)
        {
            return new UserDto()
            {
                DisplayedName = "Vlad Buriak",
                Login = "burion",
                ProfilePicture = "img/photo.jpg"
            };
        }

        public UserDto RegisterUser(UserWithPasswordDto user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> SearchUsersByLogin(string query)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string login, string password)
        {
            return true;
        }

        Task<UserDto> IUsersService.CreateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        Task<UserDto> IUsersService.GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        Task<UserDto> IUsersService.RegisterUser(UserWithPasswordDto user)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUsersService.VerifyPassword(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
