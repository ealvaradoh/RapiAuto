using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RapiAuto
{
    public class Contexto: DbContext
    {
        public Contexto(): base ("Videojuegos")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosDeInicio());
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Combustible> Combustibles { get; set; }
        public DbSet<Transmision> Transmisiones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<PerfilUsuario> PerfilesUsuarios { get; set; }
    }
}

