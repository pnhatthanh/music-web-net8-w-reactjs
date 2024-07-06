using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Data.Models
{
    public class Token
    {
        public Guid Id { get; set; }= Guid.NewGuid();   
        public string? RefereshToken { get; set; }
        public long ExpirationTime { get; set; }
        public long CreatedAt { get; set; }
        public bool isRevoked {  get; set; }
        public User? user { get; set; }
    }
}
