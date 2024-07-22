using MusicApi.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Data.DTOs
{
    public class PlayListDTO
    {
        public string PlayListName { get; set; } = "";
        public Guid UserId { get; set; }
        public List<Guid> Songs { get; set; } = new List<Guid>();
    }
}
