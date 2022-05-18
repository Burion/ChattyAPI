using AutoMapper;
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
        }
    }
}
