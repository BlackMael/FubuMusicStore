#region

using System;
using System.Linq;
using FubuCore;
using FubuMusicStore.Membership.Security;
using FubuMusicStore.Membership.Settings;
using FubuValidation;

#endregion

namespace FubuMusicStore.Membership.Services
{
   
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordValidator _validator;
        private readonly IPasswordHelperService _passwordHelperService;
        private readonly PasswordSettings _passwordSettings;

        public PasswordService(IPasswordValidator validator,
            IPasswordHelperService passwordHelperService,
            PasswordSettings passwordSettings)
        {
            _validator = validator;
            _passwordHelperService = passwordHelperService;
            _passwordSettings = passwordSettings;
        }


        public string ChangePassword(IUser user, string oldPassword, string newPassword)
        {
             return changePassword(user, oldPassword, newPassword);
        }

        private string changePassword(IUser user, string oldPassword, string newPassword)
        {
            Notification notification = _validator.Validate(newPassword);
            if (!notification.IsValid())
                throw new Exception(notification.AllMessages.FirstOrDefault().ToString());

            if(user.Password.IsEmpty())
                return _passwordHelperService.CreatePassword(newPassword);

            if (_passwordHelperService.ComparePassword(oldPassword, user.Password))
            {
               
                return _passwordHelperService.CreatePassword(newPassword);
            }

            throw new Exception("Password provided did not match the current password");
        }

        private string ResetPassword(IUser user)
        {
            var newPassword = _passwordHelperService.RandomPassword(_passwordSettings.MinRequiredPasswordLength,
                                                   _passwordSettings.MinRequiredNonAlphanumericCharacters);

            return newPassword;
        }

       

        public string ResetPassword(IUser user, string newPassword)
        {
            Notification notification = _validator.Validate(newPassword);
            if (!notification.IsValid())
                throw new Exception(notification.AllMessages.FirstOrDefault().ToString());

            return _passwordHelperService.CreatePassword(newPassword);
        }

       
    }
}