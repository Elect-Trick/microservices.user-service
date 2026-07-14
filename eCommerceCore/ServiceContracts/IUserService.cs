using eCommerceCore.DTO;
using eCommerceCore.Entities;

namespace eCommerceCore.ServiceContracts
{
    public interface IUserService
    {

       /// <summary>
       /// Definition of abstract class for dependency injection.
       /// </summary>
       /// <param name="loginRequest"></param>
       /// <returns></returns>
        Task<AuthenticationResponse?> Login(LoginDTO loginRequest);
        Task<ApplicationUser?> RegisterUser(RegisterUserDTO registerRequest);
        Task<ApplicationUser?> GetUserByUserId(Guid id);

    }
}
