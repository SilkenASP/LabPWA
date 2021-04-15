using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LabPWA.Model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Transaccion> Transaccion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>()
                .Property(e => e.NumeroCuenta)
                .IsUnicode(false);

            modelBuilder.Entity<Transaccion>()
                .Property(e => e.Accion)
                .IsUnicode(false);

            modelBuilder.Entity<Transaccion>()
                .Property(e => e.NumeroCuenta)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cuenta)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.id_Usuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cuenta1)
                .WithOptional(e => e.Usuario1)
                .HasForeignKey(e => e.id_Usuario);
        }
    }
}
