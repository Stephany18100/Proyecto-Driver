using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoWebDL.Models.Entities;
using ProyectoWebDL.Services.IServices;

namespace ProyectoWebDL.Controllers
{
    public class LibroController : Controller
    {
        //Constructor para el uso de base de datos
        private readonly ILibroServices _LibroServices;
        public LibroController(ILibroServices libroServices)
        {
            _LibroServices = libroServices;
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> Index()
        {
            try
            {
                //Uso de la lista de los articulos para que se muestre al abrir la vista

                return View(await _LibroServices.GetLibros());

                /*var response = await _articuloServices.GetArticulos();
                return View(response);*/
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear([FromForm]Libro request)
        {
            try
            {
                var response = _LibroServices.CrearLibro(request);
                //Esta funcion return sirve para volver al index despues de la accion
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Error"+ ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var response = await _LibroServices.GetByIdLibro(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Editar(Libro request)
        {
            var response = _LibroServices.EditarLibro(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _LibroServices.EliminarLibro(id);
            if(result = true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }
        }

        [HttpGet]
        //Se retorna la vista "index" de la respectiva carpeta
        public async Task<IActionResult> IndexCopia()
        {
            try
            {
                //Uso de la lista de los articulos para que se muestre al abrir la vista

                return View(await _LibroServices.GetLibros());

                /*var response = await _articuloServices.GetArticulos();
                return View(response);*/
            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error" + ex.Message);
            }
        }
    }
}
