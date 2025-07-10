using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicApi.Auth.Models
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public int UserId { get; set; }

        public LoginResponse(bool isSuccess, int userId)
        {
            IsSuccess = isSuccess;
            UserId = userId;
        }
    }
}