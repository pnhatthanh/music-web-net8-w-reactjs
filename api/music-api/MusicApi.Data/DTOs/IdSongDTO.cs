using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicApi.Data.DTOs
{
    public class IdSongDTO
    {
        [JsonPropertyName("songIds")]
        public Guid[]? idSongs { get; set; }
    }
}
