using InmueblesCrud.BusinessEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InmueblesCrud.DataAccess.Data.ObjectMapping;

namespace InmueblesCrud.DataAccess.Data
{
    public class InmueblesDbContext : DbContext
    {
        public InmueblesDbContext(DbContextOptions<InmueblesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Inmueble>().ToTable(TablaInmuebles.Inmueble).HasKey(p => new { p.InmuebleID });
            builder.Entity<TipoInmueble>().ToTable(TablaInmuebles.TipoInmueble).HasKey(p => new { p.TipoInmuebleId });

            base.OnModelCreating(builder);
        }

        public DbSet<Inmueble> Inmuebles { get; set; }
        public DbSet<TipoInmueble> TipoInmuebles { get; set; }
    }
}
