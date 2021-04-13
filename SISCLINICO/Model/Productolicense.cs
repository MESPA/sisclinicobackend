using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico.Model
{
    public class Productolicense
    {
        [Key]
        public int IdProductolicense { get; set; }
        public string NombreEmpresa { get; set; }
        public string ProductKey { get; set; }
        public DateTime TrialExpiryDate { get; set; }
    }
}
