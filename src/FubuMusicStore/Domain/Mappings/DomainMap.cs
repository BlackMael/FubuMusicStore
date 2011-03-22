using FluentNHibernate.Mapping;
using FubuFastPack.Domain;

namespace FubuMusicStore.Domain.Mappings
{
    public abstract class DomainMap<T> : ClassMap<T> where T : DomainEntity
    {
        protected DomainMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.GuidComb();
        }

    }
}