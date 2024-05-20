using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApiApplication.Dtos;

namespace NoteApplication.BusinessLogic.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> RegisterAsync(UserRegisterDto dto);
        Task<ServiceResponse<User>> LoginAsync(UserLoginDto dto);
    }
}
