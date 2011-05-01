using FubuMusicStore.Actions.Account.Login;
using FubuMusicStore.Actions.Account.Logoff;
using FubuMVC.Core;
using FubuMVC.Core.Security;
using FubuMVC.Core.Urls;
using FubuMVC.Core.View;

namespace FubuMusicStore.Actions.Account.LoginStatus
{
    public class LoginStatusAction
    {
        private readonly ISecurityContext _securityContext;
        private readonly IUrlRegistry _urlRegistry;

        public LoginStatusAction(ISecurityContext securityContext,
            IUrlRegistry urlRegistry)
        {
            _securityContext = securityContext;
            _urlRegistry = urlRegistry;
        }

        [FubuPartial]
        public LoginStatusViewModel Get(LoginStatusRequest request)
        {
            if (_securityContext.IsAuthenticated())
            {
                return new LoginStatusViewModel()
                {
                    IsAuthenticated = true,
                    UserName = _securityContext.CurrentUser.Identity.Name,
                    RawUrl = _urlRegistry.UrlFor(new LogoffRequest())
                };

            }

            return new LoginStatusViewModel()
            {
                IsAuthenticated = false,
                UserName = "",
                RawUrl = _urlRegistry.UrlFor(new LoginRequest() { ReturnUrl = "/" })
            };
        }
    }

    public class LoginStatusRequest
    {
    }

    public class LoginStatusViewModel
    {
        public string RawUrl { get; set; }
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }
    }

    public class LoginStatus : FubuPage<LoginStatusViewModel>
    {
    }
}