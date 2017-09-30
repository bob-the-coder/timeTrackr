namespace Website.Models
{
    public class UserRegisterModel : UserLoginModel
    {
        public string ConfirmPassword { get; set; }
    }
}