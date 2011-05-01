namespace FubuMusicStore.Domain.Mappings
{
    public class UserMap : DomainMap<User>
    {
        public UserMap()
        {
            Map(x => x.UserName);
            Map(x => x.IsLocked);
            Map(x => x.Password);
            Map(x => x.Email);
            Table("Users");
        }
    }
}