using Microsoft.AspNetCore.Mvc;

namespace CryptographicFailure_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DatabaseContext _context;

    public UserController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User userObj)
    {
        if (userObj == null)
        {
            return BadRequest();
        }

        var user = _context.Users.FirstOrDefault(u => u.Username == userObj.Username && u.Password == userObj.Password);

        if (user == null)
        {
            return NotFound(new
            {
                StatusCode = 404,
                Message = "User not found",
            });
        }

        return Ok(new
        {
            StatusCode = 200,
            Message = "Successful login",
        });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User userObj)
    {
        if (userObj == null)
        {
            return BadRequest();
        }

        var user = _context.Users.FirstOrDefault(u => u.Username == userObj.Username);

        if (user == null)
        {
            _context.Users.Add(userObj);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                StatusCode = 200,
                Message = "Successful registration",
            });
        }

        return NotFound(new
        {
            StatusCode = 404,
            Message = "Username already taken",
        });
    }
}
