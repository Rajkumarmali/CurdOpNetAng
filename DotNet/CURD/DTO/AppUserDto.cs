namespace CURD.DTO
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ResetPasswordDto
    {
        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}