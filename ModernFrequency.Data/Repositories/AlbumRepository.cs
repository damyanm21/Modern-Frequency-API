using Microsoft.EntityFrameworkCore;
using ModernFrequency.Data.Abstraction.Repositories;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Data.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly ModernFrequencyDbContext _context;

        public AlbumRepository(ModernFrequencyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAlbumsByArtistId(int artistId)
        {
            return await _context.Albums
                .Where(album => album.ArtistId == artistId)
                .ToListAsync();
        }
    }
}
