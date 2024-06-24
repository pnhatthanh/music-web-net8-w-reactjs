using AutoMapper;
using music_api.DTOs;
using music_api.Models;

namespace music_api.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper() { 
            CreateMap<Album,AlbumDTO>().ReverseMap();
            CreateMap<Artist, ArtistDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<PlayList, PlayListDTO>().ReverseMap();
            CreateMap<Song, SongDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
