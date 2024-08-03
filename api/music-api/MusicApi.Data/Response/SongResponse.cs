using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Data.Response
{
    public class SongResponse
    {
        public Guid SongId { get; set; }
        public string SongName { get; set; } = "";
        public string SongImagePath { get; set; } = "";
        public string SongPath { get; set; } = "";
        public ArtistResponse? artist { get; set; }

    }
}
