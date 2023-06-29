using APIControlGastos.Models;
using APIControlGastos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIControlGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IGastoRepository _repositorioGasto;
        private readonly ICobroRepository _repositorioCobro;

        public BalanceController(IGastoRepository repositorioGasto, ICobroRepository repositorioCobro)
        {
            _repositorioGasto = repositorioGasto;
            _repositorioCobro = repositorioCobro;
        }

        [HttpGet]
        [Route("/Balance/Restante/{year}/{month}")]
        public IActionResult ObtenerCantidadRestantePorMes(int year,int month)
        {
            var fecha = new DateTime(year, month, 1);
            var totalGastos = _repositorioGasto.ObtenerTotalGastosPorMes(year,month);
            var totalCobros = _repositorioCobro.ObtenerTotalCobrosPorMes(year, month);
            var cantidadRestante = totalCobros - totalGastos;

            var balance = new Balance
            {
                Fecha = fecha,
                TotalGastos = totalGastos,
                TotalCobros = totalCobros,
                CantidadRestante = cantidadRestante
            };

            return Ok(balance);

           
        }
    }

}
