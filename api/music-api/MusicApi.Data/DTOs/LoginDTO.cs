using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApi.Data.DTOs
{
    public class LoginDTO
    {
        //[EmailAddress(ErrorMessage ="Email invalid")]
        public string? Email {  get; set; }
        public string? Password { get; set; }
    }
}
