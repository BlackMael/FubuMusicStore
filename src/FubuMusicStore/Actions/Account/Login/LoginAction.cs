using FubuMusicStore.Domain;
using FubuMusicStore.Membership.Account;
using FubuMusicStore.Membership.Services;
using FubuMVC.Core.Continuations;
using FubuValidation;

namespace FubuMusicStore.Actions.Account.Login
{
    public class LoginAction
    {
        private readonly ILoginService _loginService;
        private readonly IUserService<User> _userService;

        public LoginAction(ILoginService loginService, IUserService<User> userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        public FubuContinuation Post(LoginViewModel model)
        {
            Notification notification = _loginService.LoginUser(model.UserName, model.Password, false);
            return notification.IsValid()
                       ? FubuContinuation.RedirectTo(model.ReturnUrl)
                       : FubuContinuation.TransferTo(new LoginRequest(){ReturnUrl = model.ReturnUrl, LoginFailed = true});
        }
    }
}