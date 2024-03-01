using Microsoft.EntityFrameworkCore;
using ProyectoWebDL.Context;
using ProyectoWebDL.Models.Entities;
using ProyectoWebDL.Services.IServices;
using System.Data;

namespace ProyectoWebDL.Services.Service
{
    public class UsuarioServices: IUsuarioServices
    {
        private readonly ApplicationDbContext _context;

        //Constructor para usar las tablas de base de datos
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            try
            {

                return await _context.Usuarios.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Usuario> GetByIdUsuario(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Usuario response = await _context.Usuarios.FirstOrDefaultAsync(x => x.CodigoUsuario == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Usuario> CrearUsuario(Usuario i)
        {
            try
            {
                Usuario request = new Usuario()
                {
                    NombreUsuario = i.NombreUsuario,
                    Apellidos = i.Apellidos,
                    DNI = i.DNI,
                    Domicilio = i.Domicilio,
                    Ciudad = i.Ciudad,
                    Estado = i.Estado,
                    FechaNacimiento = i .FechaNacimiento,
                };

                var result = await _context.Usuarios.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Usuario> EditarUsuario(Usuario i)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Find(i.CodigoUsuario);

                    usuario.NombreUsuario = i.NombreUsuario;
                    usuario.Apellidos = i.Apellidos;
                    usuario.DNI = i.DNI;
                    usuario.Domicilio = i.Domicilio;
                    usuario.Ciudad = i.Ciudad;
                    usuario.Estado = i.Estado;
                    usuario.FechaNacimiento = i.FechaNacimiento;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return usuario;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarUsuario(int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Find(id);

                if (usuario != null)
                {
                    var res = _context.Usuarios.Remove(usuario);
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
    }
}
