namespace Entities.Dto.Auth.Register
{
    public class UserRegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
