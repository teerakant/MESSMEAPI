using Microsoft.AspNetCore.Mvc;
using MessmeApi.Models;
using AutoMapper;
using MessmeApi.DTOs;
using Microsoft.AspNetCore.Authorization;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository,
                            IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
        return Ok(users);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userRepository.GetUserById(id);
        var userDtos = _mapper.Map<UserDto>(user);
        if (userDtos == null) return NotFound();
        return Ok(userDtos);
    }

    [HttpPost]
    public async Task<ActionResult> AddUser(User user)
    {
        await _userRepository.AddUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id) return BadRequest();
        await _userRepository.UpdateUser(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userRepository.DeleteUser(id);
        return NoContent();
    }
}
