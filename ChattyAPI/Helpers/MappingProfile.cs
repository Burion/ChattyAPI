using AutoMapper;
using ChappyAPI.Models;
using ChattyAPI.Models;
using ChattyDAL.Models;
using ChattyServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattyAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessageDto>();
            CreateMap<MessageDto, Message>();

            CreateMap<PostMessageModel, MessageDto>();

            CreateMap<User, UserDto>().ForMember(dest => dest.ProfilePicture, from => from.MapFrom(from => from.ProfilePicturePath));
            CreateMap<UserDto, User>().ForMember(dest => dest.ProfilePicturePath, from => from.MapFrom(from => from.ProfilePicture));
            CreateMap<UserWithPasswordDto, User>().ForMember(dest => dest.ProfilePicturePath, from => from.MapFrom(from => from.ProfilePicture));

            CreateMap<UpdateUserModel, UserDto>();

            CreateMap<UserLoginModel, User>();
            CreateMap<User, UserLoginModel>();

            CreateMap<UserRegisterModel, User>();
            CreateMap<User, UserRegisterModel>();
        }
    }
}
