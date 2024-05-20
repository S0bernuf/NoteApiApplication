using DataAccess.Models;
using NoteApplication.BusinessLogic.Dtos;


namespace NoteApplication.BusinessLogic.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> RegisterAsync(UserRegister dto);
        Task<ServiceResponse<User>> LoginAsync(UserLogin dto);
    }
}
