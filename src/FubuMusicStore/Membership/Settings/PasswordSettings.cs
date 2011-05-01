namespace FubuMusicStore.Membership.Settings
{
    public class PasswordSettings
    {
        public PasswordSettings()
        {
            MinRequiredPasswordLength = 8;
            MinRequiredNonAlphanumericCharacters = 1;
            PasswordStrengthRegularExpression = "";
        }

        public int MinRequiredPasswordLength { get; set; }
        public int MinRequiredNonAlphanumericCharacters { get; set; }
        public string PasswordStrengthRegularExpression { get; set; }

        public override string ToString()
        {
            var pattern = "Your password must contain at least {0} character";

            if(MinRequiredPasswordLength > 1)
                pattern += "s";

            if(MinRequiredNonAlphanumericCharacters >= 1)
            {
                pattern += " and contain at least {1} non-alphanumeric character";

                if(MinRequiredNonAlphanumericCharacters > 1)
                    pattern += "s";

                return string.Format(pattern, MinRequiredPasswordLength, MinRequiredNonAlphanumericCharacters);
            }

            return string.Format(pattern, MinRequiredPasswordLength);

        }
    }
}