using BasicApi.Auth.Models;

namespace BasicApi.Auth.Service
{
    public interface IAuthService
    {
        Task<bool> Register(RegistrationRequest request);
        Task<LoginResponse> Login(LoginRequest request);
    }
}