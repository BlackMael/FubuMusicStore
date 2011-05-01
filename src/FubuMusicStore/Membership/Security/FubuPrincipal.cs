#region

using System.Security.Principal;
using System.Threading;
using System.Web;
using FubuMusicStore.Domain;

#endregion

namespace FubuMusicStore.Membership.Security
{
    public class FubuPrincipal : IPrincipal
    {
        private readonly User _user;
        private readonly IIdentity _identity;

        private FubuPrincipal(IIdentity identity)
        {
            _identity = identity;
        }

        public FubuPrincipal(IIdentity identity, User user)
            : this(identity)
        {
            _user = user;
        }

        public static FubuPrincipal Current
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.User as FubuPrincipal;
                }
                return Thread.CurrentPrincipal as FubuPrincipal;
            }
        }

        #region IPrincipal Members

        public bool IsInRole(string role)
        {
            return true;

            //return _user != null && _user.IsInRole(role);
        }

        public User User { get { return _user; } }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        #endregion
    }
}