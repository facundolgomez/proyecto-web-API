﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<float>("Precio")
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

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoMascota")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("Domain.Entities.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
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

                    b.HasIndex("MascotaId")
                        .IsUnique();

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserRole")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator<int>("UserRole");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.HasBaseType("Domain.Entities.Usuario");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "",
                            Contrasena = "9876",
                            Direccion = "",
                            Email = "",
                            Nombre = "",
                            NombreUsuario = "facu123",
                            UserRole = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Dueno", b =>
                {
                    b.HasBaseType("Domain.Entities.Usuario");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator().HasValue(0);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Apellido = "",
                            Contrasena = "contraseña2",
                            Direccion = "",
                            Email = "",
                            Nombre = "",
                            NombreUsuario = "usuario2",
                            UserRole = 0
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.Reserva", b =>
                {
                    b.HasOne("Domain.Entities.Guarderia", "Guarderia")
                        .WithMany("Reservas")
                        .HasForeignKey("GuarderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Mascota", "Mascota")
                        .WithOne("Reserva")
                        .HasForeignKey("Domain.Entities.Reserva", "MascotaId")
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
                    b.Navigation("Reserva")
                        .IsRequired();
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
