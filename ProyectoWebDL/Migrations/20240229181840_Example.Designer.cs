﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoWebDL.Context;

#nullable disable

namespace ProyectoWebDL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240229181840_Example")]
    partial class Example
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoWebDL.Models.Entities.Libro", b =>
                {
                    b.Property<int>("CodigoLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoLibro"));

                    b.Property<DateTime?>("AnioDeEdicion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editorial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreLibro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumeroDePaginas")
                        .HasColumnType("int");

                    b.Property<string>("PaisAutor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Precio")
                        .HasColumnType("float");

                    b.HasKey("CodigoLibro");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("ProyectoWebDL.Models.Entities.Prestamo", b =>
                {
                    b.Property<int>("NumeroPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroPedido"));

                    b.Property<int>("FKCodigoLibro")
                        .HasColumnType("int");

                    b.Property<int?>("FKCodigoUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDevolucion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaMaximaDevolver")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.HasKey("NumeroPedido");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("ProyectoWebDL.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("CodigoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoUsuario"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodigoUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            CodigoUsuario = 1,
                            Apellidos = "Sosa",
                            Ciudad = "Cancun",
                            DNI = "Majo",
                            Domicilio = "1234",
                            Estado = "Quintana Roo",
                            NombreUsuario = "Maria Jose"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
