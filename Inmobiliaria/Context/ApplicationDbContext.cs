using Inmobiliaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<Inmobiliaria.Models.FormaPago> FormaPago { get; set; }

        public DbSet<Inmobiliaria.Models.Condicion> Condicion { get; set; }

        public DbSet<Inmobiliaria.Models.Venta> Venta { get; set; }

        public DbSet<Inmobiliaria.Models.TipoInmueble> TipoInmueble { get; set; }

        public DbSet<Inmobiliaria.Models.Inmueble> Inmueble { get; set; }
    }
}
