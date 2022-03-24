using ChattyDAL.Data;
using ChattyDAL.Models;
using ChattyServices.Cryptography;
using ChattyServices.Dtos;
using ChattyServices.Interfaces;
using ChattyServices.ServiceErrors;
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
            return new UserDto() { Login = user.Login, DisplayedName = user.DisplayedName, ProfilePicture = user.ProfilePicturePath };
        }

        public UserDto RegisterUser(UserRegisterModel user)
        {
            //TODO mapping
            //TODO defalut picture configurations
            var userToAdd = new User() { Login = user.Login, ProfilePicturePath = "default.jpg", Password = MD5Encrypter.Encode(user.Password) };
            
            if(_usersAccesser.GetItem(u => u.Login == user.Login) != null)
            {
                throw new ItemAlreadyExistException();
            }

            var addedUser = _usersAccesser.AddItem(userToAdd);

            var userToReturn = new UserDto() { Login = addedUser.Login, DisplayedName = addedUser.DisplayedName, ProfilePicture = addedUser.ProfilePicturePath };
            //TODO mapping

            return userToReturn;
        }

        public bool VerifyPassword(string login, string password)
        {
            var user = _usersAccesser.GetItem(u => u.Login == login);

            if(user == null)
            {
                throw new ArgumentException();
            }

            var hashedPassword = MD5Encrypter.Encode(password);

            return hashedPassword == user.Password;
        }
    }
}
