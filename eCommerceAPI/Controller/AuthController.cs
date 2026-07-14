using eCommerceCore.DTO;
using eCommerceCore.Entities;
using eCommerceCore.ServiceContracts;
using eCommerceCore.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controller
{
    [ApiController]
    [Route("api/[controller]/")   ]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<LoginDTO> _loginValidator;
        private readonly IValidator<RegisterUserDTO> _registrationValidator;
        public AuthController(IUserService userService, IValidator<LoginDTO> loginValidator, IValidator<RegisterUserDTO> registrationValidator)
        {
            _userService = userService;
            _loginValidator = loginValidator;
            _registrationValidator = registrationValidator;
        }

        [HttpPost("register")]  
        public async Task<ActionResult> RegisterUser(RegisterUserDTO registerRequest)
        {


            var validationResult = await _registrationValidator.ValidateAsync(registerRequest);
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

            if (registerRequest == null)
            {
                return BadRequest("Invalid registration data passed");
            }


            ApplicationUser? response = await _userService.RegisterUser(registerRequest);

            if (response == null ) {

                return BadRequest(registerRequest);
            }
            
            return Ok(response);

        }

        /// <summary>
        /// Enpoint for login a user in.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
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
            
            if(loginRequest == null)
            {
                return Unauthorized(loginRequest);

            }

            AuthenticationResponse? response = await _userService.Login(loginRequest);

            if (response == null || response.Success == false) {

                return Unauthorized("Failed to login");
            }
            
            return Ok(response);

        }

      
    }
}
