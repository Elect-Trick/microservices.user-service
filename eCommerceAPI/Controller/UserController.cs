using eCommerceCore.DTO;
using eCommerceCore.Entities;
using eCommerceCore.ServiceContracts;
using eCommerceCore.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controller
{
    [ApiController]
    [Route("api/[controller]/")   ]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<LoginDTO> _loginValidator;
        public UserController(IUserService userService, IValidator<LoginDTO> loginValidator)
        {
            _userService = userService;
            _loginValidator = loginValidator;
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

           
            var validationResult = await _loginValidator.ValidateAsync(loginRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Title = "Validation failed",
                    Status = 400,
                    Errors = validationResult.Errors
                                .Select(e => e.ErrorMessage)
                                .ToList()
                });
            }

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
