using AutoMapper;
using eCommerceCore.DTO;
using eCommerceCore.Entities;
using eCommerceCore.RepositoryContracts;
using eCommerceCore.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return _mapper.Map<AuthenticationResponse>(user) with { Sucess = true, Token = "token" };
    
        }

        public async Task<AuthenticationResponse?> RegisterUser(RegisterUserDTO registerRequest)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = 1,
                Email = registerRequest.Email,
                Name = "Njabulo Majenje",

            };

            ApplicationUser? regsiteredUser = await _userRepository.AddUser(user);

            if (regsiteredUser == null) {
            return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with { Sucess = true, Token = "token" };

     
        }
    }
}
