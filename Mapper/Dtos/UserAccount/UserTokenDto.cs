namespace Mapper.Dtos.UserAccount
{
    public class UserTokenDto
    {
        public string RefreshToken { get; set; }

        public string ResetPasswordToken { get; set; }
    }
}