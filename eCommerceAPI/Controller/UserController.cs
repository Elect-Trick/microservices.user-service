using eCommerceCore.DTO;
using eCommerceCore.Entities;
using eCommerceCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controller
{
    [ApiController]
    [Route("api/[controller]/")   ]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]  
        public async Task<ActionResult> RegisterUser(RegisterUserDTO registerRequest)
        {

            if (registerRequest == null)
            {
                return BadRequest("Invalid registration data passed");
            }
            AuthenticationResponse? response = await _userService.RegisterUser(registerRequest);

            if (response == null || response.Sucess == false) {

                return BadRequest(registerRequest);
            }
            
            return Ok(response);

        }

        [HttpPost("login")]  
        public async Task<ActionResult> LoginUser(LoginDTO loginRequest)
        {

            if (loginRequest == null)
            {
                return BadRequest("Invalid Login data passed");
            }
            AuthenticationResponse? response = await _userService.Login(loginRequest);

            if (response == null || response.Sucess == false) {

                return BadRequest(loginRequest);
            }
            
            return Ok(response);

        }

      
    }
}
