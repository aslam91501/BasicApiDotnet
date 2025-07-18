namespace BasicApi.Auth.Service
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
    }
}