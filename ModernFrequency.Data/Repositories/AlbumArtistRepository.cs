using ModernFrequency.Data.Abstraction.Repositories;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Data.Repositories
{
    public class AlbumArtistRepository : Repository<AlbumArtist>, IAlbumArtistRepository
    {
        public AlbumArtistRepository(ModernFrequencyDbContext context) : base(context)
        {
        }
    }
}
