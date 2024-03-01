using Microsoft.EntityFrameworkCore;
using ProyectoWebDL.Context;
using ProyectoWebDL.Models.Entities;
using ProyectoWebDL.Services.IServices;

namespace ProyectoWebDL.Services.Service
{
    public class PrestamoService
    {
        public class PrestamoServices : IPrestamoServices
        {
            private readonly ApplicationDbContext _context;

            //Constructor para usar las tablas de base de datos
            public PrestamoServices(ApplicationDbContext context)
            {
                _context = context;

            }

            public async Task<List<Prestamo>> GetPrestamo()
            {
                try
                {

                    return await _context.Prestamos.
                        ToListAsync();

                }
                catch (Exception ex)
                {
                    throw new Exception("Surgio un error" + ex.Message);
                }

            }

            public async Task<Prestamo> GetByIdPrestamo(int id)
            {
                try
                {
                    //Articulo response = await _context.Articulos.FindAsync(id);

                    Prestamo response = await _context.Prestamos.FirstOrDefaultAsync(x => x.NumeroPedido == id);
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception("Surgio un error" + ex.Message);
                }

            }
            public async Task<Prestamo> CrearPrestamo(Prestamo i)
            {
                try
                {
                    Prestamo request = new Prestamo()
                    {
                        FKCodigoLibro = i.FKCodigoLibro,
                        FKCodigoUsuario = i.FKCodigoUsuario,
                        FechaSalida = i.FechaSalida,
                        FechaMaximaDevolver = i.FechaMaximaDevolver,
                        FechaDevolucion = i.FechaDevolucion,
                      
                    };

                    var result = await _context.Prestamos.AddAsync(request);
                    _context.SaveChanges();

                    return request;
                }
                catch (Exception ex)
                {
                    throw new Exception("Surgio un error" + ex.Message);
                }
            }

            public async Task<Prestamo> EditarPrestamo(Prestamo i)
            {
                try
                {
                    Prestamo prestamo = _context.Prestamos.Find(i.NumeroPedido);

                    prestamo.FKCodigoLibro = i.FKCodigoLibro;
                    prestamo.FKCodigoUsuario = i.FKCodigoUsuario;
                    prestamo.FechaSalida = i.FechaSalida;
                    prestamo.FechaMaximaDevolver = i.FechaMaximaDevolver;
                    prestamo.FechaDevolucion = i.FechaDevolucion;
             

                    _context.Entry(prestamo).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return prestamo;

                }
                catch (Exception ex)
                {
                    throw new Exception("Succedio un error " + ex.Message);
                }
            }
            public bool EliminarPrestamo(int id)
            {
                try
                {
                    Prestamo prestamo = _context.Prestamos.Find(id);

                    if (prestamo != null)
                    {
                        var res = _context.Prestamos.Remove(prestamo);
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
}
