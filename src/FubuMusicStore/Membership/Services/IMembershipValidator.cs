using FubuMusicStore.Domain;

namespace FubuMusicStore.Membership.Services
{
    public interface IMembershipValidator
    {
        bool ValidateUser(string userName, string password);
    }

    public class MembershipValidator : IMembershipValidator
    {
        private readonly IUserService<User> _userService;
        private readonly IPasswordHelperService _passwordHelperService;

        public MembershipValidator(IUserService<User> userService, IPasswordHelperService passwordHelperService)
        {
            _userService = userService;
            _passwordHelperService = passwordHelperService;
        }

        public bool ValidateUser(string userName, string password)
        {
            var user = _userService.GetUserByLogin(userName);

            return user == null
                       ? false
                       : _passwordHelperService.ComparePassword(password, user.Password);
                                     
        }
    }
}