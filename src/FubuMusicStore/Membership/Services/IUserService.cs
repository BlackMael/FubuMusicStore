#region

using FubuMusicStore.Membership.Security;
using FubuValidation;

#endregion

namespace FubuMusicStore.Membership.Services
{

    public interface IUserService<USER> where USER : IUser
    {
        Notification Update(USER user);
        void Delete(USER user);
        USER Retrieve(object id);
        Notification Create(USER user, string password);
        USER GetUserByLogin(string name);
        USER GetUserByEmail(string email);
    }

}