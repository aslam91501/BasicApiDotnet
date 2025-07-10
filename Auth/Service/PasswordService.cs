namespace BasicApi.Auth.Service
{
    public class PasswordService : IPasswordService
    {
        private readonly int _workFactor = 12;

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, _workFactor);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}