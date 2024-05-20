using DataAccess.Models;
using Jwt.Services;
using NoteApplication.Database.Repositories;
using NoteApplication.BusinessLogic.Dtos;

namespace NoteApplication.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<ServiceResponse<User>> RegisterAsync(UserRegister dto)
        {
            // Check if user exists
            if (await _userRepository.UserExistsAsync(dto.UserName))
                return new ServiceResponse<User> { Success = false, Message = "User already exists" };

            // Create user
            var user = _jwtService.CreateUser(dto.UserName, dto.Password);
            await _userRepository.AddUserAsync(user);

            return new ServiceResponse<User> { Success = true, Data = user };
        }

        public async Task<ServiceResponse<User>> LoginAsync(UserLogin dto)
        {
            // Validate user
            var user = await _userRepository.GetUserByNameAsync(dto.UserName);
            if (user == null || !_jwtService.VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
                return new ServiceResponse<User> { Success = false, Message = "Invalid credentials" };

            return new ServiceResponse<User> { Success = true, Data = user };
        }

    }
}
