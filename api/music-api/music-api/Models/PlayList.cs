using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace music_api.Models
{
    public class PlayList
    {
        [Key]
        public int PlayListId { get; set; }
        public string PlayListName { get; set; }="";

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
       
       public List<Song> Songs{ get;}=[];
    }
}