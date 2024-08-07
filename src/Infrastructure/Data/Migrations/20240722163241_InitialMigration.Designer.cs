﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240722163241_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Domain.Entities.Guarderia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DuenoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("PrecioPorHora")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("DuenoId");

                    b.ToTable("Guarderias");
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoMascota")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("Domain.Entities.Notificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DestinatarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DestinatarioRole")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EstadoMensaje")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaCreado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RemitenteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RemitenteRole")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DestinatarioId");

                    b.HasIndex("RemitenteId");

                    b.ToTable("Notificaciones");
                });

            modelBuilder.Entity("Domain.Entities.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDesde")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaHasta")
                        .HasColumnType("TEXT");

                    b.Property<int>("GuarderiaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MascotaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoMascota")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GuarderiaId");

                    b.HasIndex("MascotaId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator<string>("UserRole");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.HasBaseType("Domain.Entities.Usuario");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator().HasValue("Cliente");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Apellido = "Balduini",
                            Contrasena = "matexd",
                            Direccion = "Corrientes 2493",
                            Email = "francoxd@gmail.com",
                            Nombre = "Franco",
                            NombreUsuario = "usuario3",
                            UserRole = "Cliente"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Dueno", b =>
                {
                    b.HasBaseType("Domain.Entities.Usuario");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator().HasValue("Dueno");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Apellido = "Gerosa",
                            Contrasena = "contraseña2",
                            Direccion = "Salta 3572",
                            Email = "marianogerosa@gmail.com",
                            Nombre = "Mariano",
                            NombreUsuario = "usuario2",
                            UserRole = "Dueno"
                        });
                });

            modelBuilder.Entity("Domain.Entities.SysAdmin", b =>
                {
                    b.HasBaseType("Domain.Entities.Usuario");

                    b.HasDiscriminator().HasValue("SysAdmin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Gomez",
                            Contrasena = "9876",
                            Direccion = "Oroño 2436",
                            Email = "facugomez@gmail.com",
                            Nombre = "Facundo",
                            NombreUsuario = "facu123",
                            UserRole = "SysAdmin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Guarderia", b =>
                {
                    b.HasOne("Domain.Entities.Dueno", "Dueno")
                        .WithMany("Guarderias")
                        .HasForeignKey("DuenoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dueno");
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Mascotas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.Notificacion", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Destinatario")
                        .WithMany("NotificacionesRecibidas")
                        .HasForeignKey("DestinatarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Usuario", "Remitente")
                        .WithMany("NotificacionesEnviadas")
                        .HasForeignKey("RemitenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destinatario");

                    b.Navigation("Remitente");
                });

            modelBuilder.Entity("Domain.Entities.Reserva", b =>
                {
                    b.HasOne("Domain.Entities.Guarderia", "Guarderia")
                        .WithMany("Reservas")
                        .HasForeignKey("GuarderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Mascota", "Mascota")
                        .WithMany("Reservas")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guarderia");

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("Domain.Entities.Guarderia", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("NotificacionesEnviadas");

                    b.Navigation("NotificacionesRecibidas");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Domain.Entities.Dueno", b =>
                {
                    b.Navigation("Guarderias");
                });
#pragma warning restore 612, 618
        }
    }
}
