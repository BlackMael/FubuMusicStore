using System.Text.RegularExpressions;
using FubuLocalization;
using FubuMusicStore.Membership.Security;
using FubuMusicStore.Membership.Settings;
using FubuValidation;

namespace FubuMusicStore.Membership.Services
{
    public interface IPasswordValidator
    {
        Notification Validate(string password);
    }

    public class PasswordValidator : IPasswordValidator
    {
        private readonly PasswordSettings _passwordSettings;

        public PasswordValidator(PasswordSettings passwordSettings)
        {
            _passwordSettings = passwordSettings;
        }

        public virtual Notification Validate(string password)
        {
            var notification = new Notification();

            if(!ValidatePasswordLength(password) || !ValidateNonAlphaContraint(password))
            {
                notification.RegisterMessage(StringToken.FromKeyString("PASSWORDLENGTH",
                                                    "Password does not meet minimum length requirements"));
            }

            if(!ValidateCustomRegex(password))
            {
                notification.RegisterMessage(StringToken.FromKeyString("PASSWORDREGEX",
                                                                       "Your password has failed to pass the systems custom password strength pattern"));
                                          
            }


            return notification;
        }

        private bool ValidatePasswordLength(string password)
        {
            var pattern = "^(?=.{" + _passwordSettings.MinRequiredPasswordLength + ",})";

            var regex = new Regex(pattern);

            return regex.IsMatch(password);
        }

        private bool ValidateNonAlphaContraint(string password)
        {
            var pattern = _passwordSettings.MinRequiredNonAlphanumericCharacters > 0
                              ? "(?=(.*\\W.*){" + _passwordSettings.MinRequiredNonAlphanumericCharacters + ",})"
                              : "";


            var regex = new Regex(pattern);

            return regex.IsMatch(password);
        }


        private bool ValidateCustomRegex(string password)
        {
            return new Regex(_passwordSettings.PasswordStrengthRegularExpression).IsMatch(password);
        }

    }
}