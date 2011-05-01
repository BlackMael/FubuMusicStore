using FubuMVC.Core;
using FubuMVC.Core.View;
using FubuValidation;

namespace FubuMusicStore.Actions.Account.Login
{
    public class GetLoginAction
    {
        public LoginViewModel Get(LoginRequest request)
        {
            return new LoginViewModel(){ReturnUrl = request.ReturnUrl, LoginFailed = request.LoginFailed};
        }
    }

    public class LoginRequest
    {
        public bool LoginFailed { get; set; }

        [QueryString]
        public string ReturnUrl { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [QueryString]
        public string ReturnUrl { get; set; }

        public bool LoginFailed { get; set; }
    }

    public class Login : FubuPage<LoginViewModel>{}
}