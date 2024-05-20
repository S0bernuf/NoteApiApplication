using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplication.Database.Repositories
{
    public interface IUserRepository
    {
        Task<bool> UserExistsAsync(string userName);
        Task AddUserAsync(User user);
        Task<User> GetUserByNameAsync(string userName);

    }
}
