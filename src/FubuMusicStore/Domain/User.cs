using System;
using FubuFastPack.Domain;
using FubuMusicStore.Membership.Security;
using FubuMusicStore.Membership.Services;

namespace FubuMusicStore.Domain
{
    public class User : DomainEntity, IUser
    {

        protected User() { }

        public User(string userName, string email)
            : this(userName, email, "")
        {
            UserName = userName;
            Email = email;
        }

        public User(string userName, string email, string password)
        {
            Password = password;
        }

        public virtual string UserName { get; set; }
        public virtual object ProviderUserKey
        {
            get { return Id; }
        }
        public virtual bool IsLocked { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; private set; }

        public virtual void ChangePassword(IPasswordService service, string oldPassword, string newPassword)
        {
            Password = service.ChangePassword(this, oldPassword, newPassword);
        }

        public virtual void ResetPassword(IPasswordService service)
        {
            ResetPassword(service);
        }

        public virtual void ResetPassword(IPasswordService service, string newPassword)
        {
            Password = service.ResetPassword(this, newPassword);
        }

        public virtual void Unlock()
        {
            IsLocked = false;
        }


        public virtual void Lock()
        {
            IsLocked = true;
        }
    }
}