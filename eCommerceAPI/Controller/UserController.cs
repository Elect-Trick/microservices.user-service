using eCommerceCore.Entities;
using eCommerceCore.RepositoryContracts;
using eCommerceCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controller;
[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationUser?>> GetUserByUserid(Guid id)
    {

        if (id== Guid.Empty)
        {
            return BadRequest("Id not found");
            
        }
        ApplicationUser? user = await _userService.GetUserByUserId(id);

        if (user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }
}