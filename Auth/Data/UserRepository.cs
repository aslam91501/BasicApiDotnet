using Dapper;
using BasicApi.Auth.Models;
using System.Data;

namespace BasicApi.Auth.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<User?> GetUser(int id)
        {
            var query = @"
                SELECT * FROM ""USERS"" 
                WHERE ""Id"" = @Id
            ";

            return await _connection.QuerySingleAsync<User>(query, new { Id = id });
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var query = @"
                SELECT * FROM ""USERS"" 
                WHERE ""Email"" = @Id
            ";

            return await _connection.QuerySingleAsync<User>(query, new { Email = email });
        }

        public async Task<bool> AddUser(User user)
        {
            var sql = @"INSERT INTO ""Users"" (""Name"", ""Email"", ""PasswordHash"", ""CreatedAt"") 
                       VALUES (@Name, @Email, @PasswordHash, @CreatedAt)";

            var affectedRows = await _connection.ExecuteAsync(sql, new
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                CreatedAt = DateTime.UtcNow
            });

            return affectedRows > 0;
        }
    }
}