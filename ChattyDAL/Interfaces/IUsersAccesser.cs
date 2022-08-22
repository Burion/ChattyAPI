using ChattyDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChattyDAL.Interfaces
{
    public interface IUsersAccesser
    {
        Task<User> InsertUser(User user);
        Task<User> UpdateUser(User user);   
        Task<User> GetUser(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> GetUsers(Expression<Func<User, bool>> predicate); 
    }
}
