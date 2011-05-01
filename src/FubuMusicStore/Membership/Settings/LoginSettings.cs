namespace FubuMusicStore.Membership.Settings
{
    public class LoginSettings
    {
        public LoginSettings()
        {
            MaxInvalidPasswordAttempts = 5;
            PasswordAttemptWindow = 10;
        }

        public int MaxInvalidPasswordAttempts { get;  set; }
        public int PasswordAttemptWindow { get;  set; }
    }
}