using System.ComponentModel.DataAnnotations;

namespace music_api.DTOs
{
    public class ArtistDTO
    {

        [Required(ErrorMessage ="Name's artist cannot empty")]
        public string ArtistName { get; set; } = "";
        [Required(ErrorMessage ="Country's artist cannot empty")]
        public string Country { get; set; } = "";
        public int YearOfBirth { get; set; }
        [Required(ErrorMessage ="Image's artist cannot empty")]
        public IFormFile Image { get; set; }
        public int Flowers { get; set; } = 0;
        public string About { get; set; } = "";
    }
}
