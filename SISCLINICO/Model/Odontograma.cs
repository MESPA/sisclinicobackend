using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico.Model
{
    public class Odontograma
    {
        [Key]
        public int IdOdontograma { get; set; }
        public string IdDoctor { get; set; }
        public string IdPaciente { get; set; }
        public string nombre { get; set; }
        public string edad { get; set; }
        public string sexo { get; set; }
        public DateTime fechaconsult { get; set; }
        public string nombreDoctor { get; set; }
        public string motivo { get; set; }
        public string plan_tratamiento { get; set; }
        public string observaciones { get; set; }
        public string diagnostic { get; set; }
        public string process { get; set; }
        public string indicacion { get; set; }
        public byte[] foto { get; set; }
        public string fichaconsult { get; set; }
        public Paciente paciente { get; set; }
       
    }
}
