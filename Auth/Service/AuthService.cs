using BasicApi.Auth.Data;
using BasicApi.Auth.Models;

namespace BasicApi.Auth.Service
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;

        public AuthService(IPasswordService passwordService, IUserRepository userRepository)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);

            if (user is null) throw new Exception("Authentication failed. User does not exist.");

            var passwordValid = _passwordService.VerifyPassword(request.Password, user.PasswordHash);

            if (!passwordValid) throw new Exception("Authentication failed. Invalid Password");

            return new LoginResponse(true, user.Id);
        }

        public async Task<bool> Register(RegistrationRequest request)
        {
            var user = new User();

            user.Id = 0;
            user.Name = request.Name;
            user.Email = request.Email;
            user.CreatedAt = DateTime.UtcNow;
            user.PasswordHash = _passwordService.HashPassword(request.Password);

            return await _userRepository.AddUser(user);
        }
    }
}