using ProyectoWebDL.Models.Entities;

namespace ProyectoWebDL.Services.IServices
{
    public interface IPrestamoServices
    {
        public Task<List<Prestamo>> GetPrestamo();
        public Task<Prestamo> GetByIdPrestamo(int id);

        public Task<Prestamo> CrearPrestamo(Prestamo i);
        public Task<Prestamo> EditarPrestamo(Prestamo i);
        public bool EliminarPrestamo(int id);
    }
}
