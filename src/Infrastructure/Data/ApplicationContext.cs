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

        public ApplicationContext(DbContextOptions<ApplicationContext> options, bool isTestingEnvironment = false) : base(options)
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
            // Configuración del discriminador para la entidad Usuario
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<UserRole>("UserRole")
                .HasValue<Dueno>(UserRole.Dueno)
                .HasValue<Cliente>(UserRole.Cliente);

            // Configuración de la tabla para todas las entidades que heredan de Usuario
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            // Configuración de la entidad Cliente
            modelBuilder.Entity<Cliente>(e =>
            {
                e.HasMany(c => c.Mascotas)
                    .WithOne(m => m.Cliente)
                    .HasForeignKey(m => m.ClienteId);
            });

            // Configuración de la entidad Mascota
            modelBuilder.Entity<Mascota>(e =>
            {
                e.HasOne(m => m.Cliente)
                    .WithMany(c => c.Mascotas)
                    .HasForeignKey(m => m.ClienteId);
                e.HasMany(m => m.Reservas)
                    .WithOne(r => r.Mascota)
                    .HasForeignKey(r => r.MascotaId);
            });

            // Configuración de la entidad Guarderia
            modelBuilder.Entity<Guarderia>(e =>
            {
                e.HasMany(g => g.Reservas)
                    .WithOne(r => r.Guarderia)
                    .HasForeignKey(r => r.GuarderiaId);
            });

            // Configuración de la entidad Dueno
            modelBuilder.Entity<Dueno>(e =>
            {
                e.HasMany(d => d.Guarderias)
                    .WithOne(g => g.Dueno)
                    .HasForeignKey(g => g.DuenoId);
            });

            // Configuración de la entidad Reserva
            modelBuilder.Entity<Reserva>(e =>
            {
                e.HasOne(r => r.Guarderia)
                    .WithMany(g => g.Reservas)
                    .HasForeignKey(r => r.GuarderiaId);
                e.HasOne(r => r.Mascota)
                    .WithMany(m => m.Reservas)
                    .HasForeignKey(r => r.MascotaId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
