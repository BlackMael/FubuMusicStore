#region

using FubuMusicStore.Membership.Security;

#endregion

namespace FubuMusicStore.Membership.Services
{
    public interface IPasswordService
    {
        string  ChangePassword(IUser user, string oldPassword, string newPassword);
        string ResetPassword(IUser user, string newPassword);
    }
}