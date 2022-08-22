using AutoMapper;
using ChattyDAL.Data;
using ChattyDAL.Interfaces;
using ChattyDAL.Models;
using ChattyServices.Cryptography;
using ChattyServices.Dtos;
using ChattyServices.Interfaces;
using ChattyServices.ServiceErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChattyServices.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersAccesser _usersAccesser;
        private readonly IMapper _mapper;

        public UsersService(IUsersAccesser usersAccesser, IMapper mapper)
        {
            _usersAccesser = usersAccesser;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByLogin(string login)
        {
            var user = await _usersAccesser.GetUser(u => u.Login == login);
            
            if (user == null)
                throw new KeyNotFoundException();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> SearchUsersByLogin(string query)
        {
            var users = await _usersAccesser.GetUsers(u => u.Login.Contains(query, StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> RegisterUser(UserWithPasswordDto user)
        {
            if(await _usersAccesser.GetUser(u => u.Login == user.Login) is not null)
            {
                throw new ItemAlreadyExistException();
            }
            
            var userToAdd = _mapper.Map<UserWithPasswordDto, User>(user);

            userToAdd.Password = MD5Encrypter.Encode(user.Password);
            
            var addedUser = await _usersAccesser.InsertUser(userToAdd);

            return _mapper.Map<UserDto>(addedUser);
        }

        public async Task<bool> VerifyPassword(string login, string password)
        {
            var user = await _usersAccesser.GetUser(u => u.Login == login);

            if(user == null)
                throw new KeyNotFoundException();

            var hashedPassword = MD5Encrypter.Encode(password);

            return hashedPassword == user.Password;
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            var userToUpdate = await _usersAccesser.GetUser(u => u.Login == user.Login);

            // TODO make up better logic 
            userToUpdate.ProfilePicturePath = user.ProfilePicture;
            userToUpdate.DisplayedName = user.DisplayedName;

            var updatedUser = await _usersAccesser.UpdateUser(userToUpdate);

            return _mapper.Map<UserDto>(updatedUser);
        }

        public async Task<string> ChangePassword(string userId, string password)
        {
            var userToUpdate = await _usersAccesser.GetUser(u => u.Login == userId);
            userToUpdate.Password = MD5Encrypter.Encode(password);
            var updatedUser = await _usersAccesser.UpdateUser(userToUpdate);

            return userToUpdate.Password;
        }
    }
}
