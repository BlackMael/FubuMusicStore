using FubuMusicStore.Actions.Account.Login;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Security;

namespace FubuMusicStore.Actions.Account.Logoff
{
    public class LogoffAction
    {
        private readonly IAuthenticationContext _authenticationContext;

        public LogoffAction(IAuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        public FubuContinuation Get(LogoffRequest request)
        {
            _authenticationContext.SignOut();
            return FubuContinuation.RedirectTo(new LoginRequest() {ReturnUrl = "/"});
        }
    }

    public class LogoffRequest
    {
    }
}