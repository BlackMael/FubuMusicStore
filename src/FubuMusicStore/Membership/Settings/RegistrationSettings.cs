namespace FubuMusicStore.Membership.Settings
{
    public class RegistrationSettings 
    {
        public RegistrationSettings()
        {
            RequiresUniqueEmail = true;
        }

        public bool RequiresUniqueEmail { get; set; }
    }
}