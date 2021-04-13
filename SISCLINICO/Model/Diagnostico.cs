using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico.Model
{
    public class Diagnostico
    {
        [Key]
        public int IdDiagnostico { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
