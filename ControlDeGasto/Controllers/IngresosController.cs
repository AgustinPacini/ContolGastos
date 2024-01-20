using ControlDeGasto.Models;
using ControlDeGasto.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControlDeGasto.Controllers
{
    public class IngresosController : Controller
    {
        
        private readonly IGastosRepository _gastosRepository;

        public IngresosController(IGastosRepository gastosRepository)
        {
            _gastosRepository = gastosRepository;
        }

        public ActionResult Ingreso()
        {
            return View(new GastoModel());
        }

       
        public ActionResult Ingresos(GastoModel gasto)
        {
            // Validar modelo
            if (!ModelState.IsValid)
            {
                return View("Ingreso", gasto);
            }

            try
            {
                // Ingresar gasto en el repositorio
                _gastosRepository.Ingreso(gasto);

                return RedirectToAction("Ingreso");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Ingreso", gasto);
            }
        }
    }
}
