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

        public UserDto RegisterUser(UserRegisterModel user)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string login, string password)
        {
            return true;
        }
    }
}
