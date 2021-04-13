using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico.Model
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int EdadCliente { get; set; }
        public string SexoCliente { get; set; }
        public string NombreDoctor { get; set; }
        public string EspecialidadDoctor { get; set; }
        public string Procesos { get; set; }
        public double Costo { get; set; }
        public double Descuento { get; set; }
        public double Pago { get; set; }
        public double Total { get; set; }
        public string Estatus { get; set; }
        public DateTime Fecha { get; set; }
        public Paciente paciente { get; set; }
        public int IdPaciente { get; set; }
    }
}
