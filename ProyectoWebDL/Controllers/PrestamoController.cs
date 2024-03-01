using Microsoft.AspNetCore.Mvc;
using ProyectoWebDL.Context;
using ProyectoWebDL.Models.Entities;
using ProyectoWebDL.Services.IServices;

namespace ProyectoWebDL.Controllers
{
        public class PrestamoController : Controller
        {
            //Constructor para el uso de base de datos
            private readonly IPrestamoServices _prestamoServices;
            //Se inicia la entrada a base de datos
            private readonly ApplicationDbContext _context;
            public PrestamoController(IPrestamoServices prestamoServices, ApplicationDbContext context)
            {
                _prestamoServices = prestamoServices;
                _context = context;
            }

            [HttpGet]
            //Se retorna la vista "index" de la respectiva carpeta
            public async Task<IActionResult> Index()
            {
                try
                {
                    //Uso de la lista de los Usuario para que se muestre al abrir la vista

                    return View(await _prestamoServices.GetPrestamo());

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
                //ViewBag.CodigoUsuario = _context.CodigoUsuario.Select(p => new SelectListItem()
                //{
                //    Text = p.Nombre,
                //    Value = p.CodigoUsuario.ToString()
                //});
                return View();
            }

            [HttpPost]
            public IActionResult Crear(Prestamo request)
            {
                try
                {
                    var response = _prestamoServices.CrearPrestamo(request);
                    //Esta funcion return sirve para volver al index despues de la accion
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    throw new Exception("Error" + ex.Message);
                }
            }

            [HttpGet]
            public async Task<IActionResult> Editar(int id)
            {
                var response = await _prestamoServices.GetByIdPrestamo(id);

                //ViewBag.CodigoUsuario = _context.CodigoUsuario.Select(p => new SelectListItem()
                //{
                //Text = p.Nombre,
                //Value = p.CodigoUsuario.ToString()
                //});
                return View(response);
            }

            [HttpPost]
            public async Task<IActionResult> Editar(Prestamo request)
            {
                var response = await _prestamoServices.EditarPrestamo(request);
                return RedirectToAction(nameof(Index));
            }

            [HttpDelete]
            public IActionResult Eliminar(int id)
            {
                bool result = _prestamoServices.EliminarPrestamo(id);
                if (true)
                {
                    return Json(new { succes = true });
                }
                else
                {
                    return Json(new { succes = false });
                }
            }
        }
    }

