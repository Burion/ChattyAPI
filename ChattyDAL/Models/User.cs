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
        public string DisplayedName { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Password { get; set; }
    }
}
