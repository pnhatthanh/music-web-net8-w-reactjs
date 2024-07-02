using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Data.Models
{
    public class Song
    {
        [Key]
        public Guid SongId { get; set; }= Guid.NewGuid();
        public string SongName { get; set;}="";
        public string SongPath{ get; set; }="";
        public string SongImagePath{ get; set; }="";
        public string SongLyrics { get; set; } = "";
        public int Duration{ get; set; }
        public DateTime ReleaseDate{ get; set; }=DateTime.Now;

        public int CategoryId{ get; set; }
        [ForeignKey("CategoryId")]
        public Category? category{ get; set; }

        public Guid ArtistId{ get; set; }
         [ForeignKey("ArtistId")]
        public Artist? artist{ get; set; }

        public List<PlayList> PlayLists{ get; set; } =new List<PlayList>();

        public List<User> Users{ get; set; } =new List<User>();

        public List<Album> Albums { get; set; } = new List<Album>();

    }
}