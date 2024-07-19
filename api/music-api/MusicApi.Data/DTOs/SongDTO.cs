using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace MusicApi.Data.DTOs
{
    public class SongDTO
    {
        [Required(ErrorMessage ="Tên bài hát không được trống")]
        public string SongName { get; set; } = "";
        [Required(ErrorMessage ="Ảnh không được trống")]
        [JsonIgnore]
        public IFormFile? ImageFile { get; set; }
        [Required(ErrorMessage = "File âm thanh không được trống")]
        [JsonIgnore]
        public IFormFile? AudioFile { get; set; }
        public int Duration { get; set; }
        public string? SongLyrics { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public Guid ArtistId {  get; set; }
        public int CategoryId { get; set; }
    }
}
