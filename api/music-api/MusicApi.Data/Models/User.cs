using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Data.Models
{
    public class User
    {
        [Key]
        [Required]
        public Guid UserId { get; set; }
        public string UserName { get; set; }="";
        public string? Password { get; set; }="";
        public string? ProviderName{ get; set; }="";
        public string? ProviderId{ get; set; }="";

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role{ get; set; }

        public List<PlayList> PlayLists{ get; set; } = new List<PlayList>();
        public List<Song> Songs{ get; set; } =new List<Song>();
    }
}