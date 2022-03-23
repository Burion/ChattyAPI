using ChattyDAL.Data;
using ChattyDAL.Models;
using ChattyServices.Dtos;
using ChattyServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Services
{
    public class UsersService : IUsersService
    {
        private readonly DataAccesser<User> _usersAccesser;

        public UsersService()
        {
            _usersAccesser = new DataAccesser<User>();
        }

        public UserDto CreateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserByLogin(string login)
        {
            var user = _usersAccesser.GetItem(u => u.Login == login);

            if(user == null)
            {
                throw new ArgumentException();
            }

            //TODO mapping
            return new UserDto() { Login = user.Login, DisplayedName = user.DisplyedName, ProfilePicture = user.ProfilePicturePath };
        }

        public bool VerifyPassword(string login, string password)
        {
            var user = _usersAccesser.GetItem(u => u.Login == login);

            if(user == null)
            {
                throw new ArgumentException();
            }

            var hashedPassword = password.GetHashCode().ToString();

            return hashedPassword == user.Password;
        }
    }
}
