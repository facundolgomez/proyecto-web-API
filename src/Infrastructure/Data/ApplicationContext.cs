using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
        public DbSet<Notificacion> Notificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuracion del discriminador para la entidad Usuario
            //nos permite tener una tabla (Usuarios) comun para Dueños y clientes
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<UserRole>("UserRole")
                .HasValue<Dueno>(UserRole.Dueno)
                .HasValue<Cliente>(UserRole.Cliente);

            modelBuilder.Entity<Cliente>()
                .ToTable("Usuarios");

            modelBuilder.Entity<Dueno>()
                .ToTable("Usuarios");

            // configuracion de la tabla para todas las entidades que heredan de Usuario
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            //me convierte el tipo enum a string para columna tipo de usuario (cliente o dueno)
            var tipoUsuarioConverter = new EnumToStringConverter<UserRole>();
            modelBuilder.Entity<Usuario>()
                .Property(e => e.UserRole)
                .HasConversion(tipoUsuarioConverter);

            //me convierte el tipo enum a string para columna tipo  mascota (gato o perro)
            var tipoMascotaConverter = new EnumToStringConverter<TipoMascota>();
            modelBuilder.Entity<Mascota>()
                .Property(e => e.TipoMascota)
                .HasConversion(tipoMascotaConverter);

            //me convierte el tipo enum a string para columna tipo  mascota (gato o perro) en la tabla Reserva
            var tipoMascotaConverter2 = new EnumToStringConverter<TipoMascota>();
            modelBuilder.Entity<Reserva>()
                .Property(e => e.TipoMascota)
                .HasConversion(tipoMascotaConverter2);

            //me convierte el tipo enum a string para columna EstadoReserva en la tabla Reserva
            var estadoConverter = new EnumToStringConverter<EstadoReserva>();
            modelBuilder.Entity<Reserva>()
                .Property(e => e.Estado)
                .HasConversion(estadoConverter);

            //me convierte el tipo enum a string para columna EstadoMensaje en la tabla Notificaciones
            var estadoMensajeConverter = new EnumToStringConverter<EstadoMensaje>();
            modelBuilder.Entity<Notificacion>()
                .Property(e => e.EstadoMensaje)
                .HasConversion(estadoMensajeConverter);


            var remitenteRoleConverter = new EnumToStringConverter<UserRole>();
            var destinatarioRoleConverter = new EnumToStringConverter<UserRole>();

            modelBuilder.Entity<Notificacion>()
                .Property(e => e.RemitenteRole)
                .HasConversion(remitenteRoleConverter);

            modelBuilder.Entity<Notificacion>()
                .Property(e => e.DestinatarioRole)
                .HasConversion(destinatarioRoleConverter);






            // configuracion de la entidad Cliente
            modelBuilder.Entity<Cliente>(e =>
            {
                    e.HasMany(c => c.Mascotas) //un cliente tiene muchas mascotas
                    .WithOne(m => m.Cliente) //cada mascota esta asociada a un unico cliente
                    .HasForeignKey(m => m.ClienteId) //clave foranea para la tabla Mascotas
                    .OnDelete(DeleteBehavior.Cascade);//esto sirve para que cuando se elimine la entidad principal
                                                      //se elimine la entidad dependiente, en este caso
                                                      //( si se elimina un cliente, se eliminan todas sus mascotas)
            });

            // configuracion de la entidad Mascota
            modelBuilder.Entity<Mascota>(e =>
            {
                    e.HasOne(m => m.Cliente)
                    .WithMany(c => c.Mascotas)
                    .HasForeignKey(m => m.ClienteId);

                    e.HasMany(m => m.Reservas)
                    .WithOne(r => r.Mascota)
                    .HasForeignKey(r => r.MascotaId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            // configuracion de la entidad Guarderia
            modelBuilder.Entity<Guarderia>(e =>
            {
                e.HasMany(g => g.Reservas)
                .WithOne(r => r.Guarderia)
                .HasForeignKey(r => r.GuarderiaId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            // configuracion de la entidad Dueno
            modelBuilder.Entity<Dueno>(e =>
            {
                    e.HasMany(d => d.Guarderias)
                    .WithOne(g => g.Dueno)
                    .HasForeignKey(g => g.DuenoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // configuracion de la entidad Reserva
            modelBuilder.Entity<Reserva>(e =>
            {
                    e.HasOne(r => r.Guarderia)
                    .WithMany(g => g.Reservas)
                    .HasForeignKey(r => r.GuarderiaId);

                    e.HasOne(r => r.Mascota)
                    .WithMany(m => m.Reservas)
                    .HasForeignKey(r => r.MascotaId);
            });

            modelBuilder.Entity<Notificacion>(e =>
            {
                e.HasOne(n => n.Remitente)
                    .WithMany(u => u.NotificacionesEnviadas) 
                    .HasForeignKey(n => n.RemitenteId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(n => n.Destinatario)
                    .WithMany(u => u.NotificacionesRecibidas) 
                    .HasForeignKey(n => n.DestinatarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });



            //ponemos entidades con los datos
            //para hacer pruebas de autenticacion y probar endpoints

            //ACLARACION: al loguearse no poner el prefijo Bearer antes del token
            //poner directamente el token(creo que es porque swagger lo pone solo)
            modelBuilder.Entity<Cliente>().HasData(
            new Cliente
            {
                Id = 1,
                NombreUsuario = "facu123",
                Nombre = "Facundo",
                Apellido = "Gomez",
                Email = "facugomez@gmail.com",
                Contrasena = "9876",
                Direccion = "Oroño 2436",
                UserRole = UserRole.Cliente,
            }
            );
        
            modelBuilder.Entity<Dueno>().HasData(
                new Dueno
                {
                    Id = 2,
                    NombreUsuario = "usuario2",
                    Nombre = "Mariano",
                    Apellido = "Gerosa",
                    Email = "marianogerosa@gmail.com",
                    Contrasena = "contraseña2",
                    Direccion = "Salta 3572",
                    UserRole = UserRole.Dueno,

                }
            );

            


            base.OnModelCreating(modelBuilder);
        }
    }
}
