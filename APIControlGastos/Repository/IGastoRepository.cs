using APIControlGastos.Models;

namespace APIControlGastos.Repository
{
    public interface IGastoRepository : IRepository<Gasto>
    {
        Task<IEnumerable<Gasto>> GetByMonth(int year, int month);
        decimal ObtenerTotalGastosPorMes(int year, int month);
    }
}
