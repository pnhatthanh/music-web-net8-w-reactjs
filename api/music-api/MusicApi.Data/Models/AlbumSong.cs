using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Data.Models
{
    public class AlbumSong
    {
        public Guid AlbumId { get; set; }
        public Album? Album { get; set; }

        public Guid SongId { get; set; }
        public Song? Song { get; set; }
    }
}
