using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Jwt.Services;
using NoteApiApplication.Dtos;
using NoteApplication.BusinessLogic.Services;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;


}
