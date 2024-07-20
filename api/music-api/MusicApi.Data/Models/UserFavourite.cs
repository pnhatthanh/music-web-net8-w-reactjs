using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Data.Models
{
    public class UserFavourite
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid SongId { get; set; }
        public Song? Song { get; set; }
    }
}
