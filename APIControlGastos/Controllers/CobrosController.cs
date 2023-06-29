using APIControlGastos.Models;
using APIControlGastos.Repository;
using Microsoft.AspNetCore.Mvc;


namespace APIControlGastos.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CobrosController : ControllerBase
    {
        
        private readonly ICobroRepository _cobroRepository;
        public CobrosController( ICobroRepository cobroRepository)
        {
            
            _cobroRepository = cobroRepository;
        }

        [HttpGet]
        [Route("/Cobros/GetAll")]
        public async Task<IEnumerable<Cobro>> GetAll()
        {
            return await _cobroRepository.GetAll();
        }
        [HttpGet]
        [Route("/Cobros/ObtenerTotalCobrosPorMes/{year}/{month}")]
        public decimal ObtenerTotalCobrosPorMes(int year, int month)
        {
            return _cobroRepository.ObtenerTotalCobrosPorMes(year, month);
        }
        [HttpGet]
        [Route("/Cobros/GetAllMonth/{year}/{month}")]
        public async Task<IEnumerable<Cobro>> GetAllMonth(int year, int month)
        {
            return await _cobroRepository.GetByMonth( year,month);
        }

        [HttpGet]
        [Route("/Cobros/GetById/{id}")]
        public async Task<ActionResult<Cobro>> GetById(int id)
        {
            var cobro = await _cobroRepository.GetById(id);

            if (cobro == null)
            {
                return NotFound();
            }

            return cobro;
        }

        [HttpPost]
        [Route("/Cobros/Create")]
        public async Task<ActionResult<Cobro>> Create(Cobro cobro)
        {
            await _cobroRepository.Add(cobro);

            return CreatedAtAction(nameof(GetById), new { id = cobro.Id }, cobro);
        }

        [HttpPut]
        [Route("/Cobros/Update/{id}")]
        public async Task<ActionResult<Cobro>> Update(int id, Cobro cobro)
        {
            if (id != cobro.Id)
            {
                return BadRequest();
            }

            await _cobroRepository.Update(cobro);

            return NoContent();
        }

        [HttpDelete]
        [Route("/Cobros/Delete/{id}")]
        public async Task<ActionResult<Cobro>> Delete(int id)
        {
            await _cobroRepository.Delete(id);

            return NoContent();
        }
    }

}


