using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Models
{
    public class User
    {
        public string Login { get; set; }
        public string DisplyedName { get; set; }
        public string Password { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}
