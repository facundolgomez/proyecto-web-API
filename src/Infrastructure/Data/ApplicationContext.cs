using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly bool isTestingEnvironment;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, bool isTestingEnvironment = false) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
            this.isTestingEnvironment = isTestingEnvironment;
        }

        public DbSet<Dueno> Duenos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<Guarderia> Guarderias { get; set; }
        public DbSet<Reserva> Reservas { get; set; }    
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración del discriminador, esto permite tener una db comun a clientes y dueños
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<UserRole>("UserRole")
                .HasValue<Dueno>(UserRole.Dueno)
                .HasValue<Cliente>(UserRole.Cliente);

            // Configuracion la entidad Cliente
            modelBuilder.Entity<Cliente>(e =>
            {
                e.ToTable("Usuarios");
                e.HasMany(c => c.Mascotas)
                 .WithOne(m => m.Cliente)
                 .HasForeignKey(m => m.ClienteId);
            });

            // Configuracion de la entidad Mascota
            modelBuilder.Entity<Mascota>(e =>
            {
                e.ToTable("Mascotas");
                e.HasMany(m => m.Reservas)
                 .WithOne(r => r.Mascota)
                 .HasForeignKey(r => r.MascotaId);
            });



            modelBuilder.Entity<Guarderia>(e =>
            {
                e.ToTable("Guarderias");
                e.HasMany(g => g.Reservas)
                .WithOne(r => r.Guarderia)
                .HasForeignKey(r => r.GuarderiaId);
            });

            
            

            base.OnModelCreating(modelBuilder); 
        }




    }

}
