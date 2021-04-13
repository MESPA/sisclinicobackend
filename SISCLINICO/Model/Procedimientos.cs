using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico.Model
{
    public class Procedimientos
    { 
        [Key]
        public int IdProcedimiento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }

        public Paciente paciente { get; set; }
        public int IdPaciente { get; set; }

    }
}
