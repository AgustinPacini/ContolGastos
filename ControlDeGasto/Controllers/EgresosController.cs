using ControlDeGasto.Models;
using ControlDeGasto.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControlDeGasto.Controllers
{
    public class EgresosController : Controller
    {
        private readonly IGastosRepository _gastosRepository;

        public EgresosController(IGastosRepository gastosRepository)
        {
            _gastosRepository = gastosRepository;
        }


        public ActionResult Egreso()
        {
            return View(new GastoModel());
        }

        [HttpPost]
        public ActionResult EgresarGasto(GastoModel gasto)
        {
            // Validar modelo
            if (!ModelState.IsValid)
            {
                return View("Egreso");
            }

            try
            {
                // Egresar gasto en el repositorio
                _gastosRepository.EgresarGastoAsync(gasto);

                return RedirectToAction("Egreso");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Egreso", ex.Message);
            }
        }
    }
}
