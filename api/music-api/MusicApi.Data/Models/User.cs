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
        public Guid UserId { get; set; }= Guid.NewGuid();
        public string UserName { get; set; }="";
        public string Password { get; set; }="";
        public string? ProviderName{ get; set; }="";
        public string? ProviderId{ get; set; }="";

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role? Role{ get; set; }

        public List<PlayList> PlayLists{ get; set; } = new List<PlayList>();
        public List<UserFavourite> UserFavourite{ get; set; } =new List<UserFavourite>();

        public List<Token> tokens { get; set; }=new List<Token>();
    }
}