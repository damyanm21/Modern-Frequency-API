using AutoMapper;
using ModernFrequency.Business.Models.DTOs.Album;
using ModernFrequency.Business.Models.DTOs.AlbumArtist;
using ModernFrequency.Business.Models.DTOs.Artist;
using ModernFrequency.Business.Models.DTOs.Track;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Business.AutoMapper
{
    public class ModernFrequencyMappingProifle : Profile
    {
        public ModernFrequencyMappingProifle()
        {
            CreateMap<Artist, ArtistGetDTO>()
            .ForMember(dest => dest.Albums, opt => opt.MapFrom(src => src.Albums.Select(a => a.Album)));
            CreateMap<Artist, ArtistPostDTO>().ReverseMap();
            CreateMap<Artist, ArtistUpdateDTO>().ReverseMap();
            CreateMap<Album, AlbumGetDTO>().ReverseMap();
            CreateMap<Album, AlbumPostDTO>().ReverseMap();
            CreateMap<Album, AlbumUpdateDTO>().ReverseMap();
            CreateMap<Album, AlbumIncludeDTO>().ReverseMap();

            CreateMap<AlbumArtist, AlbumArtistDTO>().ReverseMap();

            CreateMap<Track, TrackGetDTO>().ReverseMap();
            CreateMap<Track, TrackPostDTO>().ReverseMap();
            CreateMap<Track, TrackUpdateDTO>().ReverseMap();
        }
    }
}
