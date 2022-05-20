using ChattyServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Interfaces
{
    public interface IChatsService
    {
        public Task<IEnumerable<ChatDto>> GetChatsForUser(string userId);
    }
}
