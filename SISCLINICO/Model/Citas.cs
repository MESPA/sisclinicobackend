using SisClinico.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISCLINICO.Model
{
    public class Citas
    {
        [Key]
        public int IdCitas { get; set; }
        public int IdPaciente { get; set; }
        public string Documento { get; set; }
        public Paciente paciente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdDoctores { get; set; }
        public Doctores doctores { get; set; }
        public string NombreCompletoPaciente { get; set; }
        public string NombreCompletoDoctor { get; set; }
        
       
       
    }
}