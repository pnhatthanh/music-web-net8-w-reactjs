using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public Category? category{ get; set; }

        public Guid ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist? artist{ get; set; }
        [JsonIgnore]
        public List<PlayList> PlayLists{ get; set; } =new List<PlayList>();
        [JsonIgnore]
        public List<UserFavourite> UserFavourite { get; set; } = new List<UserFavourite>();
        [JsonIgnore]
        public List<AlbumSong> AlbumSongs { get; set; } = new List<AlbumSong>();

    }
}