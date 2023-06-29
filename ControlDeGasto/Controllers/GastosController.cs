using ControlDeGasto.Models;
using ControlDeGasto.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace ControlDeGasto.Controllers
{
    public class GastosController : Controller
    {
        private readonly IGastosRepository _gastosRepository;

        public GastosController(IGastosRepository gastosRepository)
        {
            _gastosRepository = gastosRepository;
        }
        public async Task<ActionResult> Index()
        {
            var hoy = DateTime.Today;
            var gastos = await _gastosRepository.ObtenerGastos(hoy.Month, hoy.Year);
            var dineroEnCuenta = await _gastosRepository.ObtenerDineroEnCuenta();
            ViewBag.DineroEnCuenta = dineroEnCuenta.CantidadRestante;


            return View(gastos);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            // Obtener el gasto correspondiente al id
            var gasto =await _gastosRepository.GetGastoById(id);

            if (gasto == null)
            {
                return RedirectToAction("Index");
            }

            // Eliminar el gasto
            var delet = _gastosRepository.DeleteGasto(gasto);
            return View(delet);

            // Redirigir de vuelta a la página de índice
            return RedirectToAction("Index");
        }


        //[HttpGet]
        //public async Task<ActionResult> Index(int mes,int anio)
        //{
        //    // Obtener gastos del mes actual desde el repositorio
        //    List<GastoModel> gastosDelMes = await _gastosRepository.ObtenerGastosDelMes( mes, anio);

        //    // Pasar gastos del mes actual a la vista
        //    return View(gastosDelMes);
        //}


    }
}
