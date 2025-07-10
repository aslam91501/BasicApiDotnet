using BasicApi.Auth.Models;

namespace BasicApi.Auth.Data
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);
        Task<User?> GetUser(int id);
        Task<User?> GetUserByEmail(string email);
    }
}