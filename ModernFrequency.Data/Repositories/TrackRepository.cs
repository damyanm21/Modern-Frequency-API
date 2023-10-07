using Microsoft.EntityFrameworkCore;
using ModernFrequency.Data.Abstraction.Repositories;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Data.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        private readonly ModernFrequencyDbContext _context;

        public TrackRepository(ModernFrequencyDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Track>> GetTracksByAlbumId(int albumId)
        {
            return await _context.Tracks
                .Where(track => track.AlbumId == albumId)
                .ToListAsync();
        }
    }
}
