using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIControlGastos.Context;
using APIControlGastos.Models;
using APIControlGastos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIControlGastos.Repository
{
    public class CobroRepository : BaseRepository<Cobro>, ICobroRepository
    {
        public CobroRepository(ControlgastosContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cobro>> GetByMonth(int year, int month)
        {
            return await _context.Cobros.Where(c => c.Fecha.Year == year && c.Fecha.Month == month).ToListAsync();
        }
        public decimal ObtenerTotalCobrosPorMes(int year, int month)
        {
            return _context.Set<Cobro>()
                .Where(g => g.Fecha.Month == month && g.Fecha.Year == year)
                .Sum(g => g.Monto);
        }
    }
}

