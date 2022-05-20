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

        public async Task<UserDto> RegisterUser(UserRegisterModel user)
        {
            if(_usersAccesser.GetUser(u => u.Login == user.Login) != null)
            {
                throw new ItemAlreadyExistException();
            }
            
            var userToAdd = _mapper.Map<UserRegisterModel, User>(user);

            userToAdd.Password = MD5Encrypter.Encode(user.Password);
            
            var addedUser = await _usersAccesser.UpsertUser(userToAdd);

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
    }
}
