#region

using System.Security.Principal;
using FubuMusicStore.Domain;
using FubuMusicStore.Membership.Services;
using FubuMVC.Core.Security;

#endregion

namespace FubuMusicStore.Membership.Security
{
    public class FubuPrincipalFactory : IPrincipalFactory
    {
        private readonly IUserService<User> _userService;

        public FubuPrincipalFactory(IUserService<User> userService)
        {
            _userService = userService;
        }

        public IPrincipal CreatePrincipal(IIdentity identity)
        {
            return FubuPrincipal.Current ?? new FubuPrincipal(identity,_userService.GetUserByLogin(identity.Name));
        }
    }
}