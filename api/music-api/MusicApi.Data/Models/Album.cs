using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicApi.Data.Models
{
    public class Album
    {
        [Key]
        public Guid AlbumId { get; set; }= Guid.NewGuid();
        public string AlbumName { get; set; }="";
        public string ImagePath { get; set; }="";
        public string Description { get; set; } = "";
        public DateTime CreatedTime { get; set; }=DateTime.Now;
        [JsonIgnore]
        public List<AlbumSong> AlbumSongs { get; set; } = new List<AlbumSong>();
    }
}