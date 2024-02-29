using Microsoft.EntityFrameworkCore;
using ProyectoWebDL.Context;
using ProyectoWebDL.Models.Entities;
using ProyectoWebDL.Services.IServices;
using System.ComponentModel.DataAnnotations;
using Dapper;
using System.Data;

namespace ProyectoWebDL.Services.Service
{
    public class LibroServices : ILibroServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpContextAccessor _httpContext;

        //Constructor para usar las tablas de base de datos
        public LibroServices(ApplicationDbContext context, IHttpContextAccessor httpContext, IWebHostEnvironment webHost)
        {
            _context = context;
            _httpContext = httpContext;
            _webHost = webHost;

        }

        public async Task<List<Libro>> GetLibros()
        {
            try
            {

                //return await _context.Articulos.ToListAsync();
                var response = await _context.Database.GetDbConnection().QueryAsync<Libro>("spGetLibro", new { }, commandType: CommandType.StoredProcedure);
                return response.ToList();


            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Libro> GetByIdLibro(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Libro response = await _context.Libros.FirstOrDefaultAsync(x => x.CodigoLibro == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Libro> CrearLibro(Libro i)
        {
            try
            {
                //var urlImagen = i.Img.FileName;
                //i.UrlImagenPath = @"Img/articulos/" + urlImagen;

                Libro request = new Libro()
                {
                    NombreLibro = i.NombreLibro,
                    Editorial = i.Editorial,
                    Autor = i.Autor,
                    Genero = i.Genero,
                    PaisAutor = i.PaisAutor,
                    NumeroDePaginas = i.NumeroDePaginas,
                    AnioDeEdicion = i.AnioDeEdicion,
                    Precio = i.Precio
                    //UrlImagenPath = i.UrlImagenPath,
                };

                //SubirImg(urlImagen);

                var result = await _context.Libros.AddAsync(request);
                 _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Libro> EditarLibro(Libro i)
        {
            try
            {

                Libro libro = _context.Libros.Find(i.CodigoLibro);

                libro.NombreLibro = i.NombreLibro;
                libro.Editorial = i.Editorial;
                libro.Autor = i.Autor;
                libro.Genero = i.Genero;
                libro.PaisAutor = i.PaisAutor;
                libro.NumeroDePaginas = i.NumeroDePaginas;
                libro.AnioDeEdicion = i.AnioDeEdicion;
                libro.Precio = i.Precio;

                _context.Entry(libro).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return libro;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarLibro(int id)
        {
            try
            {
                Libro libro = _context.Libros.Find(id);

                if(libro != null)
                {
                    var res = _context.Libros.Remove(libro);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        //public bool SubirImg(string Img)
        //{
        //    bool res = false;

        //    try
        //    {
        //        string rutaprincipal = _webHost.WebRootPath;
        //        var archivos = _httpContext.HttpContext.Request.Form.Files;

        //        if (archivos.Count > 0 && !string.IsNullOrEmpty(archivos[0].FileName))
        //        {

        //            var nombreArchivo = Img;
        //            var subidas = Path.Combine(rutaprincipal, "Img", "articulos");

        //            // Asegurarse de que el directorio de destino exista
        //            if (!Directory.Exists(subidas))
        //            {
        //                Directory.CreateDirectory(subidas);
        //            }

        //            var rutaCompleta = Path.Combine(subidas, nombreArchivo);

        //            using (var fileStream = new FileStream(rutaCompleta, FileMode.Create))
        //            {
        //                archivos[0].CopyTo(fileStream);
        //                res = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine($"Error al subir la imagen: {ex.Message}");
        //    }

        //    return res;
        //}
    }
}
