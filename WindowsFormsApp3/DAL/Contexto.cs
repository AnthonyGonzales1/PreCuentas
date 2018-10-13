using PresupuestoCuentas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresupuestoCuentas.DAL
{
    // Aqui agregamos public tambien, para que la clase pueda ser encontrada en cualquier parte del proyecto, 
    //y heredamos de  DbContext para que EntityFramework pueda hacer su magia
    public class Contexto : DbContext
    {
        public DbSet<Cuentas> Cuenta { get; set; }
        public DbSet<PreCuentas> PreCuenta { get; set; }
        public DbSet<TipoCuentas> TipoCuenta { get; set; }
        public DbSet<PreCuentasDetalle> Detalle { get; set; }

        // base("ConStr") para pasar la conexion a la clase base de EntityFramework 
        public Contexto() : base("ConStr")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
