using System.ComponentModel.DataAnnotations;

namespace music_api.DTOs
{
    public class SongDTO
    {
        [Required(ErrorMessage ="Tên bài hát không được trống")]
        public string SongName { get; set; } = "";
        [Required(ErrorMessage ="Ảnh không được trống")]
        public IFormFile? ImageFile { get; set; }
        [Required(ErrorMessage = "File âm thanh không được trống")]
        public IFormFile? AudioFile { get; set; }
        public int Duration { get; set; }
        public string SongLyrics { get; set; } = "";
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public Guid AlbumId { get; set; }
    }
}
