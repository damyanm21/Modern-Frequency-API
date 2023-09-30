using ModernFrequency.Business.Models.DTOs;

namespace ModernFrequency.Business.Abstraction.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackDTO>> GetAllTracksAsync();
        Task<TrackDTO> GetTrackByIdAsync(int id);
        Task CreateTrackAsync(TrackDTO track);
        Task UpdateTrackAsync(TrackDTO track);
        Task DeleteTrackAsync(int id);
    }
}
