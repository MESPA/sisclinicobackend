using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico.Model
{
    public class Usuario : IdentityUser
    {
        
        public string NombreCompleto { get; set; }
        public string Position { get; set; }
        //esta convencion no mapea la base 
        [NotMapped]
        public string Token { get; set; }
    }
}
