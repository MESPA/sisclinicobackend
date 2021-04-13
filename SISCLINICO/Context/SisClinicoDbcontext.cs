using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SisClinico.Model;
using SISCLINICO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisClinico.Context
{
    public class SisClinicoDbContext : IdentityDbContext<Usuario>
    {
            public SisClinicoDbContext(DbContextOptions options) : base(options)
            {

            }

        public DbSet<Cotizacion> Cotizacion { get; set; }
        public DbSet<Diagnostico> Diagnostico { get; set; }
        public DbSet<Doctores> Doctores { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<HistoricoPago> HistoricoPago { get; set; }
        public DbSet<Odontograma> Odontograma { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Procedimientos> Procedimientos { get; set; }
        public DbSet<Productolicense> Productolicense { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

         public DbSet<Citas> Citas { get; set; }




    }
}
