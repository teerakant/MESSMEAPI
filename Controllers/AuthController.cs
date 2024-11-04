using Microsoft.AspNetCore.Mvc;
using MessmeApi.Services;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        // Replace this with your actual user validation logic
        if (loginDto.Email == "user@example.com" && loginDto.Password == "password")
        {
            var token = _tokenService.GenerateToken("1", loginDto.Email);
            return Ok(new { Token = token });
        }

        return Ok();
    }
}

