using FubuMusicStore.Membership.Services;

namespace FubuMusicStore.Membership.Security
{
    public interface IUser
    {
        string UserName { get; }
        object ProviderUserKey { get; }
        string Email { get; set; }
        string Password { get; }
        void ChangePassword(IPasswordService service, string oldPassword, string newPassword);
        void ResetPassword(IPasswordService service);
        void ResetPassword(IPasswordService service, string newPassword);
        void Unlock();
        void Lock();
    }
}