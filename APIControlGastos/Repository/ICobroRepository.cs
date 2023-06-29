using APIControlGastos.Models;

namespace APIControlGastos.Repository
{
    public interface ICobroRepository : IRepository<Cobro>
    {
        Task<IEnumerable<Cobro>> GetByMonth(int year, int month);
        decimal ObtenerTotalCobrosPorMes(int year, int month);
    }
}
