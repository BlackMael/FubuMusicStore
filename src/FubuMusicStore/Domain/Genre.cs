using System.Collections.Generic;

namespace FubuMusicStore.Domain
{
    public class Genre
    {
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}