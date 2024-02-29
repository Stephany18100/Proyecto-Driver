using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWebDL.Models.Entities
{
    public class Prestamo
    {
        [Key]
        public int NumeroPedido { get; set; }
        [ForeignKey("Libro")]
        public int FKCodigoLibro { get; set; }
        [ForeignKey("Usuario")]
        public int? FKCodigoUsuario { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaMaximaDevolver { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}
