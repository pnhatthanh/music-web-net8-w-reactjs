using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace music_api.Models
{
    public class Artist
    {
        [Key]
        public long ArtistId { get; set; }
        public string ArtistName { get; set; }="";
        public string Country{ get; set; }="";
        public int YearOfBirth{ get; set; }
        public string ImagePath{ get; set; }="";
    }
}