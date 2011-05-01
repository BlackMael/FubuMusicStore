using FubuLocalization;
using FubuMusicStore.Membership.Services;
using FubuMVC.Core.Security;
using FubuValidation;

namespace FubuMusicStore.Membership.Account
{
    public interface ILoginService
    {
        Notification LoginUser(string userName, string password, bool rememberMe);
        void Logout();
    }
    public class LoginService : ILoginService
    {
        private readonly IAuthenticationContext _authenticationContext;
        private readonly IMembershipValidator _membershipValidator;

        public LoginService(IAuthenticationContext authenticationContext,
            IMembershipValidator membershipValidator)
        {
            _authenticationContext = authenticationContext;
            _membershipValidator = membershipValidator;
        }


        public Notification LoginUser(string userName, string password, bool rememberMe)
        {
            var notification = new Notification();
            
            if (!_membershipValidator.ValidateUser(userName, password))
            {
                notification.RegisterMessage(StringToken.FromKeyString("User Name or Password", "Please check your username and password"));
                return notification;
            }

            _authenticationContext.ThisUserHasBeenAuthenticated(userName, rememberMe);

            return notification;
        }

        public void Logout()
        {
            _authenticationContext.SignOut();
        }
    }
}