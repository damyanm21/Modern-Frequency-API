using ModernFrequency.Data.Abstraction.Repositories;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Data.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(ModernFrequencyDbContext context) : base(context)
        {
        }
    }
}
