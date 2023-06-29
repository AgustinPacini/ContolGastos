using ControlDeGasto.Models;
using ControlDeGasto.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControlDeGasto.Controllers
{
    public class CobroController : Controller
    {
        private readonly IGastosRepository _gastosRepository;

        public CobroController(IGastosRepository gastosRepository)
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
                return View("Egreso", gasto);
            }

            try
            {
                // Egresar gasto en el repositorio
                _gastosRepository.EgresarGasto(gasto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("Egreso", gasto);
            }
        }
    }
}
