using APIControlGastos.Context;
using APIControlGastos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIControlGastos.Repository
{
    public class GastoRepository : BaseRepository<Gasto>,IGastoRepository
    {
        public GastoRepository(ControlgastosContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Gasto>> GetByMonth(int year, int month)
        {
            return await _context.Gastos.Where(c => c.Fecha.Year == year && c.Fecha.Month == month).ToListAsync();
        }
        public decimal ObtenerTotalGastosPorMes(int year, int month)
        {
            return _context.Set<Gasto>()
                .Where(g => g.Fecha.Month == month && g.Fecha.Year == year)
                .Sum(g => g.Monto);
        }
        

    }
}
