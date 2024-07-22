using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Data.Models
{
    public class Token
    {
        [Key]
        public Guid Id { get; set; }= Guid.NewGuid();   
        public string? RefereshToken { get; set; }
        public long ExpirationTime { get; set; }
        public long CreatedAt { get; set; }
        public bool IsRevoked {  get; set; }
        public Guid userId { get; set; }
        [ForeignKey("userId")]
        public virtual User? User { get; set; }
    }
}
