using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyServices.Dtos
{
    public class UserWithPasswordDto : UserDto
    {
        public string Password { get; set; }
    }
}
