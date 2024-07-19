using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicApi.Data.DTOs
{
    public class AlbumDTO
    {
        [Required(ErrorMessage ="Name's album cannot empty")]
        public string AlbumName { get; set; } = "";

        public int ReleaseYear { get; set; }=DateTime.Now.Year;
        [Required(ErrorMessage ="Image's album cannot empty")]
        [JsonIgnore]
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; } = "";
        [MinLength(1,ErrorMessage ="Song cannot empty")]
        [JsonIgnore]
        public List<Guid> SongIDs { get; set; }=new List<Guid>();
    }
}
