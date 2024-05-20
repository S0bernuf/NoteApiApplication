using Microsoft.AspNetCore.Mvc;
using Jwt.Services;
using NoteApplication.BusinessLogic.Dtos;
using NoteApplication.BusinessLogic.Services;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    public UserController(IUserService userService, IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegister dto)
    {
        var result = await _userService.RegisterAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLogin dto)
    {
        var result = await _userService.LoginAsync(dto);
        if (!result.Success)
            return BadRequest(result.Message);
        var token = _jwtService.GenerateJwtToken(result.Data.UserName, result.Data.Id);
        return Ok(new { Token = token });
    }

}
