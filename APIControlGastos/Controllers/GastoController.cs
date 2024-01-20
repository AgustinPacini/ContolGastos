using APIControlGastos.Models;
using APIControlGastos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIControlGastos.Controllers
{

    
    [ApiController]
    [Route("api/[controller]")]
    public class GastoController : ControllerBase
    {
        
        private readonly IGastoRepository _gastoRepository;
        public GastoController( IGastoRepository gastoRepository)
        {
            
            _gastoRepository = gastoRepository;
        }

        [HttpGet]
        [Route("/Gasto/GetAll")]

        public async Task<IEnumerable<Gasto>> GetAll()
        {
            return await _gastoRepository.GetAll();
        }
        [HttpGet]
        [Route("/Gasto/ObtenerTotalGastosPorMes/{year}/{month}")]
        public decimal ObtenerTotalGastosPorMes(int year, int month)
        {
            return  _gastoRepository.ObtenerTotalGastosPorMes(year,month);
        }
        [HttpGet]
        [Route("/Gasto/ObtenerTodoGasto/{year}/{month}")]
        public async Task<IEnumerable<Gasto>> GetAllMonth(int year, int month)
        {
            return await _gastoRepository.GetByMonth(year, month);
        }

        [HttpGet]
        [Route("/Gasto/GetById/{id}")]
        public async Task<ActionResult<Gasto>> GetById(int id)
        {
            var cobro = await _gastoRepository.GetById(id);

            if (cobro == null)
            {
                return NotFound();
            }

            return cobro;
        }

        [HttpPost]
        [Route("/Gasto/Create")]
        public async Task<ActionResult<Gasto>> Create(Gasto gasto)
        {

            await _gastoRepository.Add(gasto);

            return CreatedAtAction(nameof(GetById), new { id = gasto.Id }, gasto);
        }

        [HttpPut]
        [Route("/Gasto/Update/{id}")]
        public async Task<ActionResult<Gasto>> Update(int id, Gasto gasto)
        {
            if (id != gasto.Id)
            {
                return BadRequest();
            }

            await _gastoRepository.Update(gasto);

            return NoContent();
        }

        [HttpDelete]
        [Route("/Gasto/Delete/{id}")]
        
        public async Task<ActionResult<Gasto>> Delete(int id)
        {
            await _gastoRepository.Delete(id);

            return NoContent();
        }
    }

}

