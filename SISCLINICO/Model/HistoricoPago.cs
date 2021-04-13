using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico.Model
{
    public class HistoricoPago
    {
        [Key]
        public int IdHistorico { get; set; }
        public int IdFactura { get; set; }
        public double Deuda { get; set; }
        public double Abono { get; set; }
        public double Resto { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public Paciente paciente { get; set; }
        public int IdPaciente { get; set; }
    }
}
