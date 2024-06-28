using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace music_api.Models
{
    public class Album
    {
        [Key]
        public Guid AlbumId { get; set; }= Guid.NewGuid();
        public Guid ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist? Artist { get; set; }
        public string AlbumName { get; set; }="";
        public int ReleaseYear{ get; set; }
        public string ImagePath { get; set; }="";
        public string Description { get; set; } = "";

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}