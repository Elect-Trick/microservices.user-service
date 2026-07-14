using AutoMapper;
using eCommerceCore.DTO;
using eCommerceCore.Entities;
using eCommerceCore.RepositoryContracts;
using eCommerceCore.ServiceContracts;

namespace eCommerceCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<AuthenticationResponse?> Login(LoginDTO loginRequest)
        {
             ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    
        }

        public async Task<ApplicationUser?> RegisterUser(RegisterUserDTO registerRequest)
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
    
            ApplicationUser? regsiteredUser = await _userRepository.AddUser(user);

            if (regsiteredUser == null) {
            return null;
            }

            return regsiteredUser;

     
        }

        public async Task<ApplicationUser?> GetUserByUserId(Guid id)
        {
            ApplicationUser? user = await _userRepository.GetUserByUserId(id);
            return user;
        }
    }
}
