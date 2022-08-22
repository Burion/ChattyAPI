using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChattyServices.Interfaces;
using ChattyServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace ChattyAPI.Controllers
{
    [Route("api/v2/chats")]
    [ApiController]
    public class ChatsV2Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ChatsV2Controller(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<dynamic> Get([FromQuery] string echo)
        {
            var dict = new Dictionary<string, string>()
            {
                ["VivintEnergy"] = "vivint-energy-opp-id",
                ["SmartHome"] = "vivint-smart-home-opp-id"
            };

            return new { Message = dict };
        }
    }
}
