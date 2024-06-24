using music_api.Models;
using System.ComponentModel.DataAnnotations;

namespace music_api.DTOs
{
    public class AlbumDTO
    {
        [Required(ErrorMessage ="Name's album cannot empty")]
        public string AlbumName { get; set; } = "";

        public int ReleaseYear { get; set; }=DateTime.Now.Year;
        [Required(ErrorMessage ="Image's album cannot empty")]
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; } = "";
        [Required(ErrorMessage ="Artist cannot empty")]
        public Guid ArtistId { get; set; }
        [MinLength(1,ErrorMessage ="Song cannot empty")]
        public List<Guid> SongIDs { get; set; }=new List<Guid>();
    }
}
