using System;

namespace Entities.Dto.Auth.Login
{
    public class UserLoginResponse
    {
        public DateTime ExpireDate { get; set; }
        public string Token { get; set; }
    }
}
