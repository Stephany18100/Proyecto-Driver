using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWebDL.Models.Entities
{
    public class Libro
    {
        [Key]
        public int CodigoLibro { get; set; }
        public string NombreLibro { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string PaisAutor { get; set; }
        public int? NumeroDePaginas { get; set; }
        public DateTime? AnioDeEdicion { get; set; }
        public decimal? Precio { get; set; }


        [NotMapped]
        [Display(Name = "Imagen")]
        public IFormFile Img { get; set; }
        public string UrlImagenPath { get; set; }
    }
}
