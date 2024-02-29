using Microsoft.EntityFrameworkCore;
using ProyectoWebDL.Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProyectoWebDL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }


        public virtual DbSet<Usuario> Usuarios { get; set; }
     
        public virtual DbSet<Libro> Libros { get; set; }

        public virtual DbSet<Prestamo> Prestamos { get; set; }

       
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insert en la tabla Rol

            //modelBuilder.Entity<Rol>().HasData(
            //    new Rol
            //    {
            //        PkRoles = 1,
            //        Nombre = "admin"
            //    },
            //    new Rol
            //    {
            //        PkRoles = 2,
            //        Nombre = "sa"
            //    });


            //Insert en la tabla usuario

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    CodigoUsuario = 1,
                    NombreUsuario = "Maria Jose",
                    Apellidos = "Sosa",
                    DNI = "Majo",
                    Domicilio = "1234",
                    Ciudad = "Cancun",
                    Estado = "Quintana Roo",
                    //FechaNacimiento = 


                });

            //lo agregue hoy
            modelBuilder.Entity<Libro>()
            .Property(l => l.Precio)
             .HasConversion<double>(); // Cambia el tipo de conversión según tus necesidades

        }
    }
}


