using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico.Model
{
    public class Paciente
    { 
        [Key]
        public int IdPaciente { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public string GrupoSanguineo { get; set; }
        public string ARS { get; set; }
        public string NSS { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public Boolean Dependiente { get; set; }
       // public DateTime FechaCreacion { get; set; }


    }
}
