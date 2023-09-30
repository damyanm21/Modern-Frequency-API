using AutoMapper;
using ModernFrequency.Business.Models.DTOs;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Business.AutoMapper
{
    public class ModernFrequencyMappingProifle : Profile
    {
        public ModernFrequencyMappingProifle()
        {
            CreateMap<Artist, ArtistDTO>().ReverseMap();
            CreateMap<Album, AlbumDTO>().ReverseMap();
            CreateMap<AlbumArtist, AlbumArtistDTO>().ReverseMap();
            CreateMap<Track, TrackDTO>().ReverseMap();
        }
    }
}
